using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniDataManagement
{
    public class TransactionRequest
    {
        [JsonProperty("AccountID")]
        public int AccountID { get; set; }
        [JsonProperty("DaysAgo")]
        public int DaysAgo { get; set; }
    }
    public class TransactionSummary
    {
        [JsonProperty("AccountID")]
        public int AccountID { get; set; }
        public int TransactionSummaryID { get; set; }
        public string TransactionSummaryName { get; set; }
        public string TransactionSummaryDate { get; set; }
        public List<TransactionDetails> ListTransactionDetails { get; set; }
    }

    public class TransactionDetails
    {
        [JsonProperty("TransactionID")]
        public int?   TransactionID { get; set; }
        [JsonProperty("ChargeDate")]
        public string ChargeDate { get; set; }
        [JsonProperty("SettlementDate")]
        public string SettlementDate { get; set; }
        [JsonProperty("ReferenceNumber")]
        public string ReferenceNumber { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Amount")]
        public double Amount { get; set; }
        [JsonProperty("Balance")]
        public double Balance { get; set; }
        [JsonProperty("TransactionType")]
        public int TransactionType { get; set; }
        [JsonProperty("TransactionStatus")]
        public int TransactionStatus { get; set; }
        public string TransactionStatusString { get; set; }
        [JsonProperty("TransactionTypeName")]
        public string TransactionTypeName { get; set; }        
    }
    public class RootTransactions
    {
        [JsonProperty("Status")]
        public int Status { get; set; }
        [JsonProperty("Error")]
        public string Error { get; set; }
        [JsonProperty("AccountAlias")]
        public string AccountAlias { get; set; }
        [JsonProperty("AccountID")]
        public int AccountID { get; set; }
        public string AccountIDEncrypted { get; set; }
        [JsonProperty("TransactionsList")]
        public List<TransactionDetails> TransactionsList { get; set; }

    }

}
