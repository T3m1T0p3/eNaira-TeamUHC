using AutoMapper;
using enairaUHC.src;
using enairaUHC.src.DbService;
using enairaUHC.src.eNairaServices;
using enairaUHC.src.eNairaServices.Dto;
using enairaUHC.src.Entity;
using enairaUHC.src.Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace enairaUHC.Controllers
{
    [ApiController]
    [Route("api/eNairaUHC/")]
    public class AccountController: ControllerBase
    {
        IRepository _repository;
        IMapper _mapper;
        IEnairaService _enairaService;
        public AccountController(IRepository context,IMapper mapper,IEnairaService enairaService)
        {
            _repository = context;
            _mapper = mapper;
            _enairaService = enairaService;
        }
        [HttpPost("register/{bvn}")]
        public async Task<IActionResult> Register(string bvn,[FromQuery]string accountNumber)
        {

            //return Ok("Site Under Construction. Please check back later");
            Console.WriteLine("Hit Register");
            try
            {
                var request = await _enairaService.GetCustomerIdAsync(bvn);
               // Console.WriteLine(await request.Content.ReadAsStringAsync());
                 //Maps response to User
                if (request.IsSuccessStatusCode)
                {
                    CustomerIdResponse data = _mapper.Map<CustomerIdResponse>(JsonConvert.DeserializeObject(await request.Content.ReadAsStringAsync()));
                    Console.WriteLine(data.response_data.BVN);
                    return Ok(request.Content);
                       //return Ok();*/
                        Console.WriteLine("Creating user");
                    User user = new User
                    {
                        BVN = bvn,
                        FirstName = data.response_data.firstName,
                        LastName = data.response_data.lastName,
                        MiddleName = data.response_data.lastName,
                        Wallet = new Wallet { BVN = bvn },
                        Email = data.response_data.email
                    };
                    //return Ok(user);
                    Console.WriteLine("Creating Enaira User");
                    var accountDetails = await _enairaService.GetAccountDetailsAsync("APISNG", data.response_data.enrollmentBank, accountNumber);
                    if (!accountDetails.IsSuccessStatusCode) throw new Exception("Invalid Account Number");
                    CustomerAccountDetailsResponse accounts = _mapper.Map<CustomerAccountDetailsResponse>(JsonConvert.DeserializeObject(await accountDetails.Content.ReadAsStringAsync()));
                    bool isValidAccount = false;
                    foreach(CustomerAccountDetails details in accounts.getcustomeracctsdetailsresp)
                    {
                        if (details.accountNo == accountNumber)
                        {
                            isValidAccount = true;
                            break;
                        }
                    }
                    if (!isValidAccount) throw new Exception("Invalid Account Number");

                    EnairaUserDto enairaUser = new EnairaUserDto { accountNumber = accountNumber,uidType="BVN" , uid = bvn, firstName=user.FirstName,middleNmae=user.MiddleName,
                                       lastName=user.LastName,emailId=user.Email,phone=data.response_data.phoneNumber1,address=data.response_data.residentialAddress,
                                        dateOfBirth=data.response_data.dateOfBirth,
                    };
                    Console.WriteLine("Calling CreateUserAsync");
                    await _repository.CreateUserAsync(user, enairaUser);
                    return CreatedAtRoute("GetUser", new { bvn = user.BVN }, user);                
                }
                throw new Exception("Error");

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost("register/Insurer")]
        public async Task<IActionResult> AddInsurer([FromBody] InsurerDto provider)
        {
            try
            {
                User user = await _repository.GetUserAsync(provider.BVN);
                Insurer insurer = _mapper.Map<Insurer>(provider);
                await _repository.AddInsurerAsync(insurer);
                return CreatedAtRoute("GetUser",new { bvn = user.BVN },user);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        
        [HttpGet("User/{bvn}",Name="GetUser")]
        public async Task<IActionResult> GetUser(string bvn)
        {
            try
            {
                var user = await _repository.GetUserAsync(bvn);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
