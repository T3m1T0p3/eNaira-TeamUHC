using AutoMapper;
using enairaUHC.src.eNairaServices.Dto;
using enairaUHC.src.Entity;
using enairaUHC.src.Entity.Dto;
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
        IMapper _mapper;
        public EnairaService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<HttpResponseMessage> GetEnairaUser(string phoneNumber,string password)
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
            
            return request;
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
        public async Task<HttpResponseMessage> CreateEnairaUserAsync(EnairaUserDto enairaUserDto)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.DefaultRequestHeaders.Add("ClientId", "7b1abdec77b10615306cb458b0c909c1");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            CreateEnairaCustomerRequestBody requestBody = new CreateEnairaCustomerRequestBody { bvn = enairaUserDto.uid, 
            channel_code = "eNairaUHC", account_no=enairaUserDto.account_no, customer_tier="1", nin=enairaUserDto.NIN, password=enairaUserDto.password, reference=enairaUserDto.uid+enairaUserDto.NIN};
            var cbnEnairaUser =await  GetEnairaUser(enairaUserDto.phone,enairaUserDto.password);
            Console.WriteLine("Checking for existing EnairaUser");
            EnairaUserResponseBody enairaUser = JsonConvert.DeserializeObject<EnairaUserResponseBody>(await cbnEnairaUser.Content.ReadAsStringAsync());
            if (enairaUser.response_code == "00") return cbnEnairaUser;
            Console.WriteLine("Creating new EnairaUser");
            StringContent content = new StringContent(JsonConvert.SerializeObject(enairaUserDto), Encoding.UTF8, "application/json");
            var request = httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/CreateConsumer", content).Result;
            //EnairaUserResponseBody newEnairaUser = _mapper.Map<EnairaUserResponseBody>(await request.Content.ReadAsStringAsync());
            return request;
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
            Console.WriteLine(request.StatusCode.ToString());
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
            //Console.WriteLine(httpClient.DefaultRequestHeaders.ToString());
            var request = httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/AccessBankMaintenancenEnquiry/v1/GetAccountDetails", content).Result;
            return request;

        }

        public async Task<string> GetTokenAsync(string userId,string password)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Add("ClientId", "7b1abdec77b10615306cb458b0c909c1");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            GetTokenRequestBody body = new GetTokenRequestBody { user_id = userId, password = $"{password}" };
            StringContent content = new StringContent(JsonConvert.SerializeObject(body),Encoding.UTF8,"application/json");
            var request = httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/CAMLLogin", content).Result;
            var response=JsonConvert.DeserializeObject<GetTokenResponseBody>(await request.Content.ReadAsStringAsync());
            return response.response_data.token;
        }

        public async Task<double> GetEnairaBalance(string userId,string token)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Add("ClientId", "7b1abdec77b10615306cb458b0c909c1");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            GetEnairaBalanceRequestBody body = new GetEnairaBalanceRequestBody { user_email = userId, user_token = $"{token}" };
            StringContent content = new StringContent(JsonConvert.SerializeObject(body),Encoding.UTF8,"application/json");
            var request = await httpClient.PostAsync("https://rgw.k8s.apis.ng/centric-platforms/uat/GetBalance", content);
            var response = await request.Content.ReadAsStringAsync();
            string balance= JsonConvert.DeserializeObject<GetEnairaBalanceResponseBody>(response).response_data.wallet_balance;
            double numBalance = 0;
            double.TryParse(balance,out numBalance);
            return numBalance;
        }
    }
}
