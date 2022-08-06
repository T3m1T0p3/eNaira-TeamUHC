using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.eNairaServices.Dto
{
    public class EnairaUserDto
    {
        public string account_no { get; set; }
        public string reference { get; set; }
        public string customer_tier { get; set; }
        public string channel_code { get; set; }
        public string BVN { get; set; }
        public string password { get; set; }
    }
}
