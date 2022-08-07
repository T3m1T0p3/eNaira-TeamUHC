using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.Entity
{
    public class CustomerAccountDetails
    {
        public string AccountClassType { get; set; }
        public string accountName { get; set; }
        public string accountNo { get; set; }
        public double amountDebitMTD { get; set; }
        public double amountDebitYTD { get; set; }
        public double amountHold { get; set; }
        public double amountLastCredit { get; set; }
        public double amountLastDebit { get; set; }
        public string aTMStatus { get; set; }
        public double availableBalance { get; set; }
        public string branchCode { get; set; }
        public string branchName { get; set; }
        public string BVN { get; set; }
        public double clearedBalance { get; set; }
        public double closingBalance { get; set; }
        public string COMP_MIS_2 { get; set; }
        public string COMP_MIS_4 { get; set; }
        public string COMP_MIS_8 { get; set; }
        public string currency { get; set; }
        public string currencyCode { get; set; }
        public string custID { get; set; }
        public string CustomerCategory { get; set; }
        public string CustomerCategoryDesc { get; set; }
        public string customerName { get; set; }
        public string customerNo { get; set; }
        public string dateofbirth { get; set; }
        public string dateOpened { get; set; }
        public string daueLimit { get; set; }
        public string dAUEStartDate { get; set; }
        public string e_mail { get; set; }
        public string interestPaidYTD { get; set; }
        public string interestReceivedYTD { get; set; }
        public string lastCreditDate { get; set; }
        public string lastCreditInterestAccrued { get; set; }
        public string lastDebitDate { get; set; }
        public string lastDebitInterestAccrued { get; set; }
        public string lastMaintainedBy { get; set; }
        public string lastSerialofCheque { get; set; }
        public string lastUsedChequeNo { get; set; }
        public string maintenanceAuthorizedBy { get; set; }
        public double netBalance { get; set; }
        public double oDLimit { get; set; }
        public double openingBalance { get; set; }
        public string phone { get; set; }
        public string productCode { get; set; }

        public string productName { get; set; }
        public string profitCenter { get; set; }
        public string serviceChargeYTD { get; set; }
        public string signatory { get; set; }
        public string staff { get; set; }

        public string strAdd1 { get; set; }
        public string strAdd2 { get; set; }
        public string strAdd3 { get; set; }
        public string strCity { get; set; }
        public string strCountry { get; set; }
        public string strState { get; set; }
        public string strZip { get; set; }
        public double taxAccrued { get; set; }
        public double unavailableBalance { get; set; }
        public double unclearedBalance { get; set; }
        public string customersegment { get; set; }
        public string PNDReasonANDCode { get; set; }
        public string TierDetails { get; set; }
        public string hasSweep { get; set; }
        public string sweepAmt { get; set; }
        public string sweepData { get; set; }
        public string LoanPrequalifyInfo { get; set; }
        public string gender { get; set; }
        public string migrateacctPrompt { get; set; }
        public string custAddress1 { get; set; }
        public string custAddress2 { get; set; }
        public string custAddress3 { get; set; }
        public string custAddress4 { get; set; }
        public string firstName { get; set; }
        public string middleNmae { get; set; }
        public string lastNmae { get; set; }
        public string customerType { get; set; }
        public string customerTIN { get; set; }
        public string cheque_book_facility { get; set; }
    }
}
