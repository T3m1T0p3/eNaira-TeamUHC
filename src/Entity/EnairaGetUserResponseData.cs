namespace enairaUHC.src.Entity
{
    public class EnairaGetUserResponseData
    {
        public string uid { get; set; }
        public string uid_Type { get; set; }
        public string title { get; set; } = "";
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string kyc_status { get; set; }
        public string phone { get; set; }
        public string email_id { get; set; }
        public string state_of_residence { get; set; }
        public string lga { get; set; }
        public string address { get; set; }
        public string inst_code { get; set; }
        public string enaira_bank_code { get; set; }
        public string relationship_bank { get; set; }
        public string country_of_origin {get; set;}
        public string state_of_origin { get; set; }
        public string tier { get; set; }
        public WalletInfo wallet_info { get; set; }
        public string account_number {get; set;}
        public string country_of_birth { get; set; }
        public string password { get; set; }
        public string referrers_code { get; set; }
    }
}
