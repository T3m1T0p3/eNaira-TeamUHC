using enairaUHC.src;
using enairaUHC.src.DbService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace enairaUHC.Controllers
{
    public class AccountController: ControllerBase
    {
        IRepository _repository;
        public AccountController(IRepository context)
        {
            _repository = context;
        }
        public async Task<IActionResult> Register(string bvn)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("ClientId", "7b1abdec77b10615306cb458b0c909c1");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Object requestBody=new {
                "searchParameter": "27069078382",
                "verificationType": "NIN-SEARCH"
                }
        }
            var request = httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/customer/identity/NINValidationByNIN",new StringContent(bvn)).Result;

            //Maps response to User
            if (request.IsSuccessStatusCode)
            {
                try
                {
                    var data = JsonConvert.SerializeObject(request);
                    User user = new User { BVN = bvn, FirstName = data[""], LastName = data[""] , MiddleName=data[],
                    Wallet=new Wallet { AccountNumber=data[""], CustomerTier="",ChannelCode="",BVN=bvn}
                    };
                    await _repository.CreateUserAsync(user);
                    return Ok();
                }

                catch(Exception e)
                {
                    return BadRequest("Unable to register User "+e.Message);
                }
            }
            return BadRequest();
            
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

        public IActionResult GetUser()
        {
            return null;
        }
    }
}
