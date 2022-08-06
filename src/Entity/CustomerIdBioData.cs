using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity
{
    public class CustomerIdBioData
    {
        public string responseCode { get; set;}
        public string BVN {get; set;}
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public string enrollmentBank { get; set; }
        public string enrollmentBranch { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string levelOfAccount { get; set; }
        public string lgaOfOrigin { get; set; }
        public string lgaOfResidence { get; set; }
        public string NIN { get; set; }
        public string nameOnCard { get; set; }
        public string maritalStatus { get; set; }
        public string nationality { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string residentialAddress { get; set; }
        public string stateOfOrigin { get; set; }
        public string stateOfResidence { get; set; }
        public string watchListed { get; set; }
    }
}
