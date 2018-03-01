using OmniDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MoneyNowPortal.Controllers
{
    public class PaymentsController : BaseController
    {
        // GET: Payments
        public async Task<ActionResult> Make()
        {
            if (!await AuthorizePage("MakePayment"))
                return RedirectToAction("NoAccess", "Home");
            return View();
        }
    }
}