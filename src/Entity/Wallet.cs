using System;
using System.ComponentModel.DataAnnotations;

namespace enairaUHC.src
{
    public class Wallet
    {
        [Key]
        public Guid WalletAddress { get; set; }
        public string BVN { get; set; }
        
        public double Balance { get; set; } = 0;
    }
}