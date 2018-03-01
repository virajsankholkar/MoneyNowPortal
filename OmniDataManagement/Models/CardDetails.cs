using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniDataManagement
{
    public class CardDetails
    {
        public int CardID { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public string Balance { get; set; }
        public string MinPaymentDue { get; set; }
        public string AvailableCredit { get; set; }
        public string NextPaymentDate { get; set; }
        public bool IsLocked { get; set; }
        public bool IsFrozen { get; set; }
        public bool IsRestricted { get; set; }
        public List<RewardDetails> CardRewards { get; set; }
        public int totalCardPoints
        {
            get
            {
                return CardRewards.Sum(m => m.RewardPoints);
            }            
        }
    }
}
