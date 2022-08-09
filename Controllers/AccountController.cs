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
        [HttpPost("register/{bvn}/{accountNumber}")]
        public async Task<IActionResult> Register(string bvn,string accountNumber)
        {
            Console.WriteLine("Hit Register");
            try
            {
                //ar request = await _enairaService.GetCustomerIdAsync(bvn);
                if (true)//request.IsSuccessStatusCode)
                {
                    //CustomerIdResponse data = _mapper.Map<CustomerIdResponse>(JsonConvert.DeserializeObject(await request.Content.ReadAsStringAsync()));
                    //Console.WriteLine(data.response_data.BVN);
                    Console.WriteLine("Creating user account");
                    /*User user = new User
                    {
                        BVN = bvn,
                        FirstName = data.response_data.firstName,
                        LastName = data.response_data.lastName,
                        MiddleName = data.response_data.lastName,
                        Wallet = new Wallet { BVN = bvn },
                        Email = data.response_data.email
                    };*/
                    Console.WriteLine("Creating Enaira User");
                    //var accountDetails = await _enairaService.GetAccountDetailsAsync("APISNG", data.response_data.enrollmentBank, accountNumber);
                    Console.WriteLine("Enaira User creted");
                    /*if (false) throw new Exception("Invalid Account Number");
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

                    EnairaUserDto enairaUser = new EnairaUserDto { accountNumber = accountNumber,uidType="BVN" , uid = bvn, firstName=user.FirstName,middleName=user.MiddleName,
                                       lastName=user.LastName,emailId=user.Email,phone=data.response_data.phoneNumber1,address=data.response_data.residentialAddress,
                                        dateOfBirth=data.response_data.dateOfBirth,NIN=data.response_data.NIN,password=bvn+data.response_data.NIN
                    };

                    Console.WriteLine("Calling CreateUserAsync");
                    await _repository.CreateUserAsync(user, enairaUser);*/
                    User user = new User
                    {
                        BVN = bvn,
                        FirstName = "FIRSTNAME",//data.response_data.firstName,
                        LastName = "LASTNAME",//data.response_data.lastName,
                        MiddleName = "MiddlenMe",//data.response_data.lastName,
                        Wallet = new Wallet { BVN = "BVN" },
                        Email = "newUser@email.com"//data.response_data.email
                    };
                    return Ok(user);//CreatedAtRoute("GetUser", new { bvn = user.BVN }, user);                
                }
                throw new Exception();// "AFF Server Error: "+request.Headers.ToString());

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        //4574249a887cc8df76ce3bfa4ebfb65e
        //fcfae588b4c471c048baca5e62eed5b2

        [HttpPost("register/{bvn}")]
        public async Task<IActionResult> RegisterWithoutCreatingWallet(string bvn)
        {

            Console.WriteLine("Hit Register without wallet");
            try
            {
                ///var request = await _enairaService.GetCustomerIdAsync(bvn);
                if (true)//request.IsSuccessStatusCode)
                {
                    //CustomerIdResponse data = _mapper.Map<CustomerIdResponse>(JsonConvert.DeserializeObject(await request.Content.ReadAsStringAsync()));
                    //Console.WriteLine(data.response_data.BVN);
                    Console.WriteLine("Creating user");
                    User user = new User
                    {
                        BVN = bvn,
                        FirstName = "FIRSTNAME",//data.response_data.firstName,
                        LastName = "LASTNAME",//data.response_data.lastName,
                        MiddleName = "MiddlenMe",//data.response_data.lastName,
                        Wallet = new Wallet { BVN = "BVN" },
                        Email = "newUser@email.com"//data.response_data.email
                    };

                    //Console.WriteLine("Calling CreateUserAsync");
                    //await _repository.CreateUserAsync(user);
                    return Ok(user);//CreatedAtRoute("GetUser", new { bvn = user.BVN }, user);
                }
                throw new Exception();//await request.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register/EnairaWallet")]
        public async Task<IActionResult> CreateEnairaCustomer(EnairaUserDto data)
        {
            //User user = await_repository.GetUserAsync(bvn);
            try
            {
                //var newENairaUser =await  _enairaService.CreateEnairaUserAsync(data);

                return Ok(new EnairaUserResponseBody { response_code = "00", response_message = "Success", response_data = new EnairaGetUserResponseData() }); //await newENairaUser.Content.ReadAsStringAsync());
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
                //User user = await _repository.GetUserAsync(provider.BVN);
                //Insurer insurer = _mapper.Map<Insurer>(provider);
                //await _repository.AddInsurerAsync(insurer);
                return Ok(new Insurer { InsurerId="HealthCareInsuance unique Id",WalletAddress="Company's eNaira Address",Name="Company Name"});//CreatedAtRoute("GetUser",new { bvn = user.BVN },user);
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
                //var user = await _repository.GetUserAsync(bvn);
                User user = new User
                {
                    BVN = bvn,
                    FirstName = "FIRSTNAME",//data.response_data.firstName,
                    LastName = "LASTNAME",//data.response_data.lastName,
                    MiddleName = "MiddlenMe",//data.response_data.lastName,
                        Wallet = new Wallet { BVN = "BVN" },
                    Email = "newUser@email.com"//data.response_data.email
                };

                return Ok(user);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
