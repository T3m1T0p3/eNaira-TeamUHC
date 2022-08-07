﻿using enairaUHC.src.eNairaServices.Dto;
using enairaUHC.src.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace enairaUHC.src.eNairaServices
{
    public class EnairaService:IEnairaService
    {

        public async Task<object> GetEnairaUser(string phoneNumber,string password)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            var authByte = Encoding.ASCII.GetBytes($"password:{password}");
            var authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authByte));

            httpClient.DefaultRequestHeaders.Add("ClientId", "7b1abdec77b10615306cb458b0c909c1");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = authHeader;

            GetEnairaUserRequestBody requestBody = new GetEnairaUserRequestBody
            {
                phone_number = phoneNumber
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            
            var request = httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/enaira-user/GetUserDetailsByPhone", content).Result;
            string responseBody = await request.Content.ReadAsStringAsync();
        }
        //No schema for GetBalance endpoint
        public async Task<double> GetEnairaBalance(User user)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.DefaultRequestHeaders.Add("ClientId", "7b1abdec77b10615306cb458b0c909c1");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            GetEnairaBalanceRequestBody requestBody = new GetEnairaBalanceRequestBody
            {
                user_email = user.Email
            };


            StringContent content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            Console.WriteLine(httpClient.DefaultRequestHeaders.ToString());
            var request = httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/GetBalance", content).Result;
            string responseBody = await request.Content.ReadAsStringAsync();
            return 0;
        }

        //No schema for createuserconsomer endpoint
        //vague post parameters
        public async Task<HttpStatusCode> CreateEnairaUserAsync(EnairaUserDto enairaUserDto)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.DefaultRequestHeaders.Add("ClientId", "7b1abdec77b10615306cb458b0c909c1");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //CreateEnairaCustomerRequestBody requestBody = new CreateEnairaCustomerRequestBody { bvn = enairaUserDto.BVN, 
            //channel_code = "eNairaUHC", account_no=enairaUserDto.account_no, customer_tier="1", nin=enairaUserDto.NIN, password=enairaUserDto.password, reference=enairaUserDto.BVN+enairaUserDto.NIN};
            var cbnEnairaUser = GetEnairaUser(enairaUserDto.phone);
            
            StringContent content = new StringContent(JsonConvert.SerializeObject(enairaUserDto), Encoding.UTF8, "application/json");
            Console.WriteLine(httpClient.DefaultRequestHeaders.ToString());
            var request = httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/CreateConsumer", content).Result;
            return request.StatusCode;
        }



        public async Task<HttpResponseMessage> GetCustomerIdAsync(string bvn)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.DefaultRequestHeaders.Add("ClientId", "7b1abdec77b10615306cb458b0c909c1");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            GetCustomerDetailsRequestBody requestBody = new GetCustomerDetailsRequestBody { bvn = $"{bvn}", channel_code = "APISNG" };
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            Console.WriteLine(httpClient.DefaultRequestHeaders.ToString());
            var request = httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/customer/identity/BVN", content).Result;
            return request;
        }

        public async Task<HttpResponseMessage> GetAccountDetailsAsync(string channel, string bankCode, string accountNumber)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.DefaultRequestHeaders.Add("ClientId", "7b1abdec77b10615306cb458b0c909c1");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            GetAccountDetailsRequestBody requestBody = new GetAccountDetailsRequestBody { channel_code = $"{channel}", 
                bank_code = $"{bankCode}" ,account_no = $"{accountNumber}" };

            StringContent content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            Console.WriteLine(httpClient.DefaultRequestHeaders.ToString());
            var request = httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/customer/identity/BVN", content).Result;
            return request;

        }
    }
}
