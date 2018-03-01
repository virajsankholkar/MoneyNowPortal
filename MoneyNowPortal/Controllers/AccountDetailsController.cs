using Newtonsoft.Json;
using OmniDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MoneyNowPortal.Controllers
{
    public class AccountDetailsController : BaseController
    {
        // GET: AccountDetails
        public async Task<ActionResult> Index()
        {
            if (!await AuthorizePage("MyAccount"))
                return RedirectToAction("NoAccess", "Home");

            LoginResponseDetails userLoginDetails = GetUserLoginDetails();
            try
            {
                if (userLoginDetails != null)
                {
                    OmniDataItemAPI injector = new OmniDataItemAPI(_WebAPIURL);
                    RootAccounts rootAccount = await injector.GetAccountsFromAPI(userLoginDetails.Token);
                    if (rootAccount != null && rootAccount.Status == 0)
                    {
                        List<CardAccountDetails> cardAccountDetails = new List<CardAccountDetails>();

                        foreach (var card in rootAccount.CardList)
                        {
                            CardAccountDetails cardEntity = new CardAccountDetails();
                            cardEntity.CardID = card.CardID;
                            cardEntity.CardName = card.CardName;
                            cardEntity.CardStatus = card.CardStatus;
                            cardEntity.AccountList = new List<AccountDetails>();

                            foreach (var account in card.AccountList)
                            {
                                AccountDetails entity = new AccountDetails();
                                entity.AccountID = account.AccountID;
                                entity.AccountAlias = account.AccountAlias;
                                entity.AccountName = account.AccountName;
                                entity.AccountStatus = account.AccountStatus;
                                entity.AccountType = account.AccountType;
                                entity.AccountTypeName = Constants.GetAccountType(account.AccountType);
                                entity.AccountIDEncrypted = OmniDataManagement.Helpers.StringCipher.Encrypt(account.AccountID.ToString(), OmniDataManagement.Constants.PassPhrase);
                                cardEntity.AccountList.Add(entity);
                            }
                            cardAccountDetails.Add(cardEntity);
                        }
                        return View(cardAccountDetails);
                    }
                }
            }
            catch(Exception ex)
            {
                await AddToErrorLog(userLoginDetails.Token, "MyAccount", ex.Message);
                return View();
            }
            return View();        
        }

        [HttpPost]
        public async Task<ActionResult> AddNewAccountDetails(string myParams)
        {
            LoginResponseDetails userLoginDetails = GetUserLoginDetails();
            try
            {
                if (!await AuthorizePage("ModifyAccount"))
                    return RedirectToAction("NoAccess", "Home");

                if (userLoginDetails != null)
                {
                    OmniDataItemAPI injector = new OmniDataItemAPI(_WebAPIURL);

                    dynamic stuff = JsonConvert.DeserializeObject(myParams);
                    var requestObjectAdd = JsonConvert.DeserializeObject<RequestAccountAdd>(stuff);                  

                    RequestAccountAdd requestObject = new RequestAccountAdd();
                    requestObject.AccountName = requestObjectAdd.AccountName;
                    requestObject.AccountType = Convert.ToInt32(requestObjectAdd.AccountType);
                    requestObject.Description = requestObjectAdd.Description;
                    requestObject.EffectiveDate = Convert.ToDateTime(requestObjectAdd.EffectiveDate);
                    GenericResponse returnObject = await injector.AddAccountRequestFromAPI(userLoginDetails.Token, requestObject);

                    if (returnObject.Status == 0)
                        return Json(new { Success = true, ErrorMessage = "" });
                    else
                        return Json(new { Success = false, ErrorMessage = returnObject.Error });
                }
                //place holders for calling the Web API's to perform the functions.
                return Json(new { Success = false, ErrorMessage = "User Token not valid or expired. Please login again." });
            }
            catch (Exception ex)
            {
                await AddToErrorLog(userLoginDetails.Token, "MyAccount", ex.Message);
                return Json(new { Success = false, ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAccountAliasName(string myParams)
        {
            LoginResponseDetails userLoginDetails = GetUserLoginDetails();
            try
            {
                if (!await AuthorizePage("ModifyAccount"))
                    return RedirectToAction("NoAccess", "Home");

                if (userLoginDetails != null)
                {
                    OmniDataItemAPI injector = new OmniDataItemAPI(_WebAPIURL);

                    dynamic stuff = JsonConvert.DeserializeObject(myParams);
                    RequestAccountAlias requestObject = new RequestAccountAlias();                    
                    requestObject = JsonConvert.DeserializeObject<RequestAccountAlias>(stuff);
                    GenericResponse returnObject = await injector.UpdateAccountsAliasFromAPI(userLoginDetails.Token, requestObject);

                    if (returnObject.Status == 0)
                        return Json(new { Success = true, ErrorMessage = "" });
                    else
                        return Json(new { Success = false, ErrorMessage = returnObject.Error });
                }
                //place holders for calling the Web API's to perform the functions.
                return Json(new { Success = false, ErrorMessage = "User Token not valid or expired. Please login again." });
            }
            catch(Exception ex)
            {
                await AddToErrorLog(userLoginDetails.Token, "MyAccount", ex.Message);
                return Json(new { Success = false, ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> RequestAccountChangeStatus(string myParams)
        {
            LoginResponseDetails userLoginDetails = GetUserLoginDetails();
            try
            {
                if (!await AuthorizePage("ModifyAccount"))
                    return RedirectToAction("NoAccess", "Home");
                
                if (userLoginDetails != null)
                {
                    OmniDataItemAPI injector = new OmniDataItemAPI(_WebAPIURL);

                    RequestAccountStatus requestObject = new RequestAccountStatus();
                    dynamic stuff = JsonConvert.DeserializeObject(myParams);
                    requestObject = JsonConvert.DeserializeObject<RequestAccountStatus>(stuff);

                    /*requestObject.AccountID = Convert.ToInt32(requestObjectAdd.AccountID);
                    requestObject.NewStatus = requestObjectAdd.NewStatus;
                    requestObject.Description = requestObjectAdd.Description;
                    requestObject.EffectiveDate = Convert.ToDateTime(requestObjectAdd.EffectiveDate);*/

                    GenericResponse returnObject = await injector.ChangeAccountStatusFromAPI(userLoginDetails.Token, requestObject);

                    if (returnObject.Status == 0)
                        return Json(new { Success = true, ErrorMessage = "" });
                    else
                        return Json(new { Success = false, ErrorMessage = returnObject.Error });
                }
                //place holders for calling the Web API's to perform the functions.
                return Json(new { Success = false, ErrorMessage = "User Token not valid or expired. Please login again." });
            }
            catch (Exception ex)
            {
                await AddToErrorLog(userLoginDetails.Token, "MyAccount", ex.Message);
                return Json(new { Success = false, ErrorMessage = ex.Message });
            }
        }        
    }
}