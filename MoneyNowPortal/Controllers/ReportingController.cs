using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MoneyNowPortal.Controllers
{
    public class ReportingController : BaseController
    {
        // GET: Reporting
        public async Task<ActionResult> Index()
        {
            if (!await AuthorizePage("MyReports"))
                return RedirectToAction("NoAccess", "Home");

            return View();
        }
    }
}