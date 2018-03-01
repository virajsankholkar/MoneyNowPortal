using OmniDataManagement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MoneyNowPortal.Controllers
{
    public class HomeController : BaseController
    {        
        public async Task<ActionResult> Index()
        {
            if (!await AuthorizePage("MyAccount"))
                return RedirectToAction("Login", "Home");

            return View();
        }

        public ActionResult CSIndex()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(OmniDataManagement.LoginRequestDetails model)
        {            
            if (model != null && this.ModelState.IsValid)
            {
                model.TTL = Constants.UserLoginTTL;
                model.POCType = Constants.UserLoginPOC;
                model.InstitutionID = Constants.UserLoginInstitutionID;

                RESTClient<LoginResponseDetails> client = new RESTClient<LoginResponseDetails>(_WebAPIURL);
                var userLoginResponseDetails = await client.PostAsync(model, Constants.UserLoginURLParameters);

                if (userLoginResponseDetails != null)
                {
                    if (userLoginResponseDetails.StatusCode == 0)
                    {
                        Session["UserLogin"] = userLoginResponseDetails;
                        Session["UserName"] = userLoginResponseDetails.UserName;

                        //You can then just use the User.Identity.Name instead of the @Session["Name"].
                        FormsAuthentication.SetAuthCookie(userLoginResponseDetails.UserName, model.RememberMe);

                        if (!string.IsNullOrEmpty(Request.Form["ReturnUrl"]))
                        {
                            return RedirectToAction(Request.Form["ReturnUrl"].Split('/')[2]);
                        }
                        if (userLoginResponseDetails.RoleID == 1)
                            return RedirectToAction("Index", "Home");
                        else
                            return RedirectToAction("CSIndex", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Username and/or password is incorrect.";
                    }
                }
                else
                    ViewBag.Message = "Sorry, we can't find that page. It might be an old link or maybe it moved.";
            }          

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserLogin"] = null;
            Session["UserName"] = null;
            return RedirectToAction("Login", "Home");
        }

        public ActionResult NoAccess()
        {
            return View();
        }
    }
}