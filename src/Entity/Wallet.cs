using System;

namespace enairaUHC.src
{
    public class Wallet
    {
        public string BVN { get; set; }
        public Guid WalletAddress { get; set; }
        
        public double Balance { get; set; } = 0;
    }
}