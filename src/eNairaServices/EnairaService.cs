using enairaUHC.src.eNairaServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace enairaUHC.src.eNairaServices
{
    public class EnairaService:IEnairaService
    {
        public void CreateEnairaUser(EnairaUserDto enairaUserDto)
        {
            HttpClient http = new HttpClient();
            //POST TO Enaira registration Endpoint
            return;
        }
    }
}
