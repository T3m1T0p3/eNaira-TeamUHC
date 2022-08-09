using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity.Dto
{
    public class GetTokenResponseBody
    {
        public string response_code { get; set; }
        public string response_message { get; set; }
        public GetTokenResponseData response_data { get; set; }
        
    }
}
