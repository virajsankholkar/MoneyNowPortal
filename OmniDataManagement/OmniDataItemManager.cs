using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniDataManagement
{
    public class OmniDataItemManager
    {
        #region Constructor
        public OmniDataItemManager(OmniDataManagementBase injector)
        {
            DataReader = injector;             
        }
        #endregion

        #region Public Properties
        public OmniDataManagementBase DataReader { get; set; }
        public List<CardAccountDetails> CardAccountDetailsList { get; set; }
        public List<TransactionSummary> TransactionSummaryDetailsList { get; set; }
        public List<CardDetails> CardDetailsList { get; set; }
        #endregion

        public List<CardAccountDetails> LoadAccountDetails(string userToken)
        {
            CardAccountDetailsList = DataReader.LoadCardAccountDetails(userToken);

            return CardAccountDetailsList;
        }

        public List<TransactionSummary> LoadTransactionDetails()
        {
            TransactionSummaryDetailsList = DataReader.LoadTransactionSummaryDetails();

            return TransactionSummaryDetailsList;
        }

        public List<CardDetails> LoadCardDetails()
        {
            CardDetailsList = DataReader.LoadCardDetails();

            return CardDetailsList;
        }

    }
}
