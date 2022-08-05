using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public string FromWallet { get; set; }
        public string ToWallet { get; set; }
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
