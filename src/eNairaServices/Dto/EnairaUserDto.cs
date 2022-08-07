using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.eNairaServices.Dto
{
    public class EnairaUserDto
    {
        public string channelCode { get; set; } = "APISNG";
        public string uid { get; set; }
        public string uidType { get; set; }
        public string userName { get; set; }
        public string title { get; set; } = "";
        public string firstName { get; set; }
        public string middleNmae { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string emailId { get; set; }
        public string postalCode { get; set; } = "";
        public string city { get; set; }
        public string address { get; set; }
        public string countryOfResidence { get; set; } = "NG";
        public string tier { get; set; } = "2";
        public string accountNumber { get; set; }
        public string taxIdentificationNumber { get; set; } = "";
        public string dateOfBirth { get; set; }
        public string countryOfBirth { get; set; }="NG"
        public string referralCode { get; set; } = "Team57";
        public string remarks { get; set; } = "Created through eNaira hackathon Team57";

    }
}
