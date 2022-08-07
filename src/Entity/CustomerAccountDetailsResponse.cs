using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity
{
    public class CustomerAccountDetailsResponse
    {
        public string ResponseCode {get; set;}
        public string ResponseMessage { get; set; }
        public List<CustomerAccountDetails> getcustomeracctsdetailsresp { get; set; }
    }
}
