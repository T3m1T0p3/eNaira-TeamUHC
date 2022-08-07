using enairaUHC.src.eNairaServices.Dto;
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
        public Task<HttpStatusCode> CreateEnairaUserAsync(EnairaUserDto user);
        public Task<HttpResponseMessage> GetCustomerIdAsync(string bvn);

        public Task<HttpResponseMessage> GetAccountDetailsAsync(string channel, string bankCode, string accountNumber);

        public Task<object> GetEnairaUser();

        public Task<double> GetEnairaBalance(User user);
    }
}
