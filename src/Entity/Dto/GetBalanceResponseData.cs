using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity.Dto
{
    public class GetBalanceResponseData
    {
        public string wallet_balance { get; set; }
        public string kyc_status { get; set; }
        public string wallet_type { get; set; }
        public string withdrawal_preauth_state { get; set; }
        public string currency_code { get; set; }
    }
}
