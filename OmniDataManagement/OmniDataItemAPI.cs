using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OmniDataManagement.Models;

namespace OmniDataManagement
{
    public class OmniDataItemAPI 
    {
        #region Constructors
        public OmniDataItemAPI() 
        {
        }
        public OmniDataItemAPI(string webAPIURL)
        {
            WebAPIURL = webAPIURL;
        }

        public string WebAPIURL;
        #endregion

        #region Load Method

        public async Task<RootAccounts> GetAccountsFromAPI(string userToken)
        {         
            if (!string.IsNullOrWhiteSpace(userToken))
            {
               
                RESTClient<RootAccounts> client = new RESTClient<RootAccounts>(WebAPIURL);
                var accountsResponseDetails = await client.PostAsync(null, string.Format("{0}{1}",Constants.AccountsURLParameters, userToken));

                if (accountsResponseDetails != null)
                {
                    return accountsResponseDetails;
                }
            }

            return null;
        }

        public async Task<GenericResponse> UpdateAccountsAliasFromAPI(string userToken, RequestAccountAlias reqObject)
        {
            GenericResponse accountsResponseDetails = new OmniDataManagement.GenericResponse();
            if (!string.IsNullOrWhiteSpace(userToken))
            {
                RESTClient<GenericResponse> client = new RESTClient<GenericResponse>(WebAPIURL);
                
                accountsResponseDetails = await client.PostAsync(reqObject, string.Format("{0}{1}", Constants.UpdateAccountAliasURLParameters, userToken));

                if (accountsResponseDetails != null)
                {
                    return accountsResponseDetails;
                }
            }

            return accountsResponseDetails;
        }

        public async Task<GenericResponse> ChangeAccountStatusFromAPI(string userToken, RequestAccountStatus reqObject)
        {
            GenericResponse accountsResponseDetails = new OmniDataManagement.GenericResponse();
            if (!string.IsNullOrWhiteSpace(userToken))
            {
                RESTClient<GenericResponse> client = new RESTClient<GenericResponse>(WebAPIURL);

                accountsResponseDetails = await client.PostAsync(reqObject, string.Format("{0}{1}", Constants.ChangeAccountStatusURLParameters, userToken));

                if (accountsResponseDetails != null)
                {
                    return accountsResponseDetails;
                }
            }

            return accountsResponseDetails;
        }

        public async Task<GenericResponse> AddToErrorLogFromAPI(string userToken, ErrorLogAPI requestObject)
        {
            GenericResponse accountsResponseDetails = new OmniDataManagement.GenericResponse();
            if (!string.IsNullOrWhiteSpace(userToken))
            {
                RESTClient<GenericResponse> client = new RESTClient<GenericResponse>(WebAPIURL);

                accountsResponseDetails = await client.PostAsync(requestObject, string.Format("{0}{1}", Constants.AddErrorLogURLParameters, userToken));

                if (accountsResponseDetails != null)
                {
                    return accountsResponseDetails;
                }
            }

            return accountsResponseDetails;
        }

        public async Task<GenericResponse> AddAccountRequestFromAPI(string userToken, RequestAccountAdd reqObject)
        {
            GenericResponse accountsResponseDetails = new OmniDataManagement.GenericResponse();
            if (!string.IsNullOrWhiteSpace(userToken))
            {
                RESTClient<GenericResponse> client = new RESTClient<GenericResponse>(WebAPIURL);

                accountsResponseDetails = await client.PostAsync(reqObject, string.Format("{0}{1}", Constants.AddAccountRequestURLParameters, userToken));

                if (accountsResponseDetails != null)
                {
                    return accountsResponseDetails;
                }
            }

            return accountsResponseDetails;
        }

        public async Task<RootTransactions> GetTransactionsFromAPI(TransactionRequest tReq, string userToken)
        {
            if (!string.IsNullOrWhiteSpace(userToken))
            {
                RESTClient<RootTransactions> client = new RESTClient<RootTransactions>(WebAPIURL);
                var transResponseDetails = await client.PostAsync(tReq, string.Format("{0}{1}", Constants.TransactionURLParameters, userToken));

                if (transResponseDetails != null)
                {
                    return transResponseDetails;
                }
            }

            return null;
        }

        #endregion
    }
}
