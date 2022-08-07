using enairaUHC.src.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace enairaUHC.src
{
    public class User
    {
        //public Guid UserId { get; set; }
        [Required]
        public string BVN { get; set; }
        public string Email { get; set; }
        public Wallet Wallet { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        string AccountNumber { get; set; }
        public string MiddleName { get; set; }

        //public Sha256 PasswordHash { get; set; }
        public string InsureranceStatus { get; set; }

        public string UserType { get; set; }
        public string phone { get; set; }


    }
}
