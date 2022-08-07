using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity
{
    public class GetEnairaUserRequestBody
    {
        public string phone_number { get; set; }
        public string user_type { get; set; } = "USER";
        public string channel_code { get; set; } = "APISNG";
    }
}
