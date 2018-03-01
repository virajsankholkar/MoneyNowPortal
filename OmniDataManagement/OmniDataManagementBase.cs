using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniDataManagement
{
    /// <summary>
    /// Base class for all "Injector" classes
    /// </summary>
    public abstract class OmniDataManagementBase
    {
        #region Constructor
        public OmniDataManagementBase()
        {
            Location = string.Empty;
            WebAPIURL = string.Empty;
        }

        public OmniDataManagementBase(string location)
        {
            WebAPIURL = string.Empty;
            Location = location;
        }

        public OmniDataManagementBase(string location, string webAPIURL)
        {
            Location = location;
            WebAPIURL = webAPIURL;
        }
        #endregion

        public string Location { get; set; }

        public string WebAPIURL { get; set; }

        public abstract List<CardAccountDetails> LoadCardAccountDetails(string userToken = "");
        public abstract List<TransactionSummary> LoadTransactionSummaryDetails();
        public abstract List<CardDetails> LoadCardDetails();

    }
}
