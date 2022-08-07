using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity
{
    public class CreateEnairaCustomerRequestBody
    {
        public string channel_code { get; set; }
        public string customer_tier {get; set;}
        public string reference { get; set; }
        public string account_no { get; set; }
        public string bvn { get; set; }
        public string password { get; set; }
        public string nin { get; set; }
    }
}
