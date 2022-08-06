using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.eNairaServices
{
    public class EnairaUser
    {
        public Guid EnairaUserId { get; set; }
        public string AccountNumber { get; set; }
        public string Reference { get; set; }
        public string CustomerTier { get; set; }
        public string ChannelCode { get; set; }
        public string BVN { get; set; }
        public string Password { get; set; }
    }
}
