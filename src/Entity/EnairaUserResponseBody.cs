using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity
{
    public class EnairaUserResponseBody
    {
        public string response_code { get; set; }
        public string response_message { get; set; }
        public EnairaGetUserResponseData response_data { get; set; }
    }   
}
