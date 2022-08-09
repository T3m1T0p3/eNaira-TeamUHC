using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity.Dto
{
    public class EnairaBalance
    {
        public double Balance { get; set; }
        public string KycStatus { get; set; } = "ACCEPTED";
        public string WalletType { get; set; } = "Registered User";
    }
}
