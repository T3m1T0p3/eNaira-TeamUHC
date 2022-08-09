using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity.Dto
{
    public class GetTokenResponseData
    {
        public string alias {get; set;}
        public string needsPasswordReset { get; set; }
        public string token { get; set; }
    }
}
