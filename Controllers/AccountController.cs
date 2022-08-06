using AutoMapper;
using enairaUHC.src;
using enairaUHC.src.DbService;
using enairaUHC.src.eNairaServices;
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
        public AccountController(IRepository context,IMapper mapper)
        {
            _repository = context;
            _mapper = mapper;
        }
        [HttpPost("register/{bvn}")]
        public async Task<IActionResult> Register(string bvn)
        {

            //return Ok("Site Under Construction. Please check back later");
            Console.WriteLine("Hit Register");
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);
            
                httpClient.DefaultRequestHeaders.Add("ClientId","7b1abdec77b10615306cb458b0c909c1");
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
                RequestBody requestBody = new RequestBody { bvn = $"{bvn}", channel_code = "APISNG" };
                StringContent content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8,"application/json");
                Console.WriteLine(httpClient.DefaultRequestHeaders.ToString());
                var request = httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/customer/identity/BVN", content).Result;
                Console.WriteLine(await request.Content.ReadAsStringAsync());
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
                        Wallet = new Wallet { BVN = bvn }
                    };
                    Console.WriteLine("Creating Enaira User");

                    EnairaUser enairaUser = new EnairaUser { AccountNumber = "45679", CustomerTier = "1", ChannelCode = "APING", BVN = bvn, Password = bvn, Reference = "2345" };
                    Console.WriteLine("Calling CreateUserAsync");
                    await _repository.CreateUserAsync(user, enairaUser);
                    return CreatedAtRoute("GetUser", new { bvn = user.BVN }, user);
                }
                throw new Exception("Error");

            }
            catch(Exception e)
            {
                return BadRequest();
            }
            
            //post to https://rgw.k8s.apis.ng/centric-platforms/uat/CreateConsumer
            /* body
             * {
                "channel_code": "NEXTGEN",
                "customer_tier": "2",
                "reference": "NXG34567898FGHJJB1",
                "account_no": "0689658501",
                 "bvn": "22152793496",
                "password": "Password10$$",
                "nin": ""
                }



             REQ: POST https://rgw.k8s.apis.ng/centric-platforms/uat/CreateConsumer
                Headers:
                Content-Type: application/json
                Accept: application/json
                ClientId: 7b1abdec77b10615306cb458b0c909c1*/
        }

        [HttpPost("register/Insurer")]
        public async Task<IActionResult> AddInsurer([FromBody] InsurerDto provider)
        {
           return Ok("See User Registration page at /register/yourBVN");
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
            return Ok("No user in the Databse");
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
