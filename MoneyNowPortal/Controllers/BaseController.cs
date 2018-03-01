using OmniDataManagement;
using OmniDataManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MoneyNowPortal.Controllers
{
    public class BaseController : Controller
    {
        //More generic code will go in the base controller
        public string _WebAPIURL = ConfigurationManager.AppSettings["OmniWebAPIURL"];

        public Dictionary<int, string> AccountDetailsNameValue = new Dictionary<int, string>();
        public async Task<bool> AuthorizePage (string pageName)
        {
            if (Session["UserLogin"] != null)
            {
                LoginResponseDetails userLoginDetails = (LoginResponseDetails)Session["UserLogin"];
                var permissionObject = userLoginDetails.Permissions.Where(p => p.POC == pageName).FirstOrDefault();
                if (permissionObject != null)
                    return permissionObject.Allowed;
                else
                {
                    await AddToErrorLog(userLoginDetails.Token, pageName, "User not authorized to access this page.");
                    return false;
                }
            }

            return false;
        }

        public LoginResponseDetails GetUserLoginDetails()
        {
            if (Session["UserLogin"] != null)
            {
                return (LoginResponseDetails)Session["UserLogin"];               
            }

            return null; 
        }

        public async Task<string> AddToErrorLog(string userToken, string POC, string ErrorMessage)
        {
            try
            {                
                if (userToken != null)
                {
                    OmniDataItemAPI injector = new OmniDataItemAPI(_WebAPIURL);

                    ErrorLogAPI requestObject = new ErrorLogAPI();
                    requestObject.Error = ErrorMessage;
                    requestObject.POC = POC;
                    GenericResponse returnObject = await injector.AddToErrorLogFromAPI(userToken, requestObject);                   
                }                
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                //do nothing
            }

            return string.Empty;
        }

    }
}