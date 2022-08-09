using enairaUHC.src.eNairaServices.Dto;
using enairaUHC.src.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace enairaUHC.src.eNairaServices
{
    public interface IEnairaService
    {
        public Task<HttpResponseMessage> CreateEnairaUserAsync(EnairaUserDto data);
        public Task<HttpResponseMessage> GetCustomerIdAsync(string bvn);

        public Task<HttpResponseMessage> GetAccountDetailsAsync(string channel, string bankCode, string accountNumber);

        public Task<HttpResponseMessage> GetEnairaUser(string phone, string password);

        public Task<double> GetEnairaBalance(User user);
        public Task<double> GetEnairaBalance(string userId,string password);
        public Task<string> GetTokenAsync(string userId, string password);
    }
}
