using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniDataManagement
{
    public class AccountDetails
    {
        [JsonProperty("AccountID")]
        public int AccountID { get; set; }
        [JsonProperty("AccountType")]
        public int AccountType { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountName { get; set; }
        [JsonProperty("AccountAlias")]
        public string AccountAlias { get; set; }
        [JsonProperty("AccountStatus")]
        public int AccountStatus { get; set; }
        public string AccountIDEncrypted { get; set; }
    }

    public class CardAccountDetails
    {
        [JsonProperty("CardID")]
        public int? CardID { get; set; }
        [JsonProperty("CardName")]
        public string CardName { get; set; }
        [JsonProperty("CardStatus")]
        public int CardStatus { get; set; }
        [JsonProperty("AccountList")]
        public List<AccountDetails> AccountList { get;  set;}
    }
    
    public class ChangeRequestAccountDetails
    {        
        public int ChangeRequestType { get; set; }
        public string ChangeRequestDescription { get; set; }
        public DateTime ChangeRequestDateTime { get; set; }
        public int? CurrentAccountStatus { get; set; }

    }

    public class RequestAccountAlias
    {
        [JsonProperty("AccountID")]
        public int AccountID { get; set; }
        [JsonProperty("NewAlias")]
        public string NewAlias { get; set; }
    }

    public class RequestAccountStatus
    {
        [JsonProperty("AccountID")]
        public int AccountID { get; set; }
        [JsonProperty("NewStatus")]
        public string NewStatus { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("EffectiveDate")]
        public DateTime EffectiveDate { get; set; }
    }

    public class RequestAccountAdd
    {
        [JsonProperty("AccountName")]
        public string AccountName { get; set; }
        [JsonProperty("AccountType")]
        public int AccountType { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("EffectiveDate")]
        public DateTime EffectiveDate { get; set; }
    }

    public class RootAccounts
    {
        [JsonProperty("Status")]
        public int Status { get; set; }
        [JsonProperty("Error")]
        public string Error { get; set; }
        [JsonProperty("CardList")]
        public List<CardAccountDetails> CardList { get; set; }   

    }

    public class GenericResponse
    {
        [JsonProperty("Status")]
        public int Status { get; set; }
        [JsonProperty("Error")]
        public string Error { get; set; }
    }

}
