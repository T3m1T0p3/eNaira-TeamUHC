using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity.Dto
{
    public class GetTokenRequestBody
    {
        public string user_id { get; set; }
        public string password { get; set; }
        public string allow_tokenization { get; set; } = "Y";
        public string user_type { get; set; } = "USER";
        public string channel_code { get; set; } = "APISNG";
    }
}
