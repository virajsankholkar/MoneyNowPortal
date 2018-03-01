using OmniDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MoneyNowPortal.Controllers
{
    public class TransactionsController : BaseController
    {
        // GET: Transactions        
        public async Task<ActionResult> Index(string accountID = "")
        {
            if (!await AuthorizePage("MyTransactions"))
                return RedirectToAction("NoAccess", "Home");
            
            LoginResponseDetails userLoginDetails = GetUserLoginDetails();
            RootTransactions emptyRootTransaction = new RootTransactions();
            emptyRootTransaction.TransactionsList = new List<TransactionDetails>();

            try
            {
                if (userLoginDetails != null)
                {
                    await GetAccountDetails(userLoginDetails.Token);
                    if (AccountDetailsNameValue.Count > 0)
                    {
                        int defaultAccountID = AccountDetailsNameValue.FirstOrDefault().Key;
                        if (!string.IsNullOrWhiteSpace(accountID))
                        {
                            var accountIDDecryted = OmniDataManagement.Helpers.StringCipher.Decrypt(accountID, OmniDataManagement.Constants.PassPhrase);
                            defaultAccountID = Convert.ToInt32(accountIDDecryted);
                        }
                        

                        OmniDataItemAPI injector = new OmniDataItemAPI(_WebAPIURL);

                        TransactionRequest tReq = new TransactionRequest();
                        tReq.AccountID = defaultAccountID;
                        tReq.DaysAgo = Constants.TransactionDays;

                        RootTransactions rootTransaction = await injector.GetTransactionsFromAPI(tReq, userLoginDetails.Token);

                        if (rootTransaction != null && rootTransaction.Status == 0)
                        {
                            foreach (var trans in rootTransaction.TransactionsList)
                            {
                                trans.Description = trans.Description;
                                trans.SettlementDate = trans.SettlementDate;
                                trans.TransactionStatusString = Constants.GetTransactionStatus(trans.TransactionStatus);
                                trans.ChargeDate = trans.ChargeDate;
                                trans.TransactionType = trans.TransactionType;
                                trans.TransactionTypeName = Constants.GetTransactionType(trans.TransactionType);
                            }
                        }

                        return View(rootTransaction);
                    }
                    return View(emptyRootTransaction); // Return a new page not found view 
                }
            }
            catch(Exception ex)
            {
                await AddToErrorLog(userLoginDetails.Token, "MyTransactions", ex.Message);
                return View(emptyRootTransaction);
            }
            return View(emptyRootTransaction);
        }
        public async Task GetAccountDetails(string userToken)
        {
            try
            {
                OmniDataItemAPI injector = new OmniDataItemAPI(_WebAPIURL);
                RootAccounts rootAccount = await injector.GetAccountsFromAPI(userToken);
                List<SelectListItem> items = new List<SelectListItem>();
                if (rootAccount != null && rootAccount.Status == 0)
                {
                    foreach (var card in rootAccount.CardList)
                    {
                        foreach (var account in card.AccountList)
                        {
                            var AccountIDEncrypted = OmniDataManagement.Helpers.StringCipher.Encrypt(account.AccountID.ToString(), OmniDataManagement.Constants.PassPhrase);
                            AccountDetailsNameValue.Add(account.AccountID, account.AccountAlias);
                            items.Add(new SelectListItem()
                            {
                                Text = account.AccountAlias,
                                Value = AccountIDEncrypted
                            });                            
                        }
                    }
                }

                ViewBag.AccountDetails = new SelectList(items, "Value", "Text");
            }
            catch (Exception ex)
            {
                await AddToErrorLog(userToken, "MyTransactions", ex.Message);                
            }
        }
    }
}

