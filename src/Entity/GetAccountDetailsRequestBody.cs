using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity
{
    public class GetAccountDetailsRequestBody
    {
        public string channel_code { get; set; }
        public string bank_code { get; set; }
        public string account_no { get; set; }
    }
}
