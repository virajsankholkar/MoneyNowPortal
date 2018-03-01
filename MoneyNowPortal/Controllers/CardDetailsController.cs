using OmniDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MoneyNowPortal.Controllers
{
    public class CardDetailsController : BaseController
    {
        // GET: CardDetails
        public async Task<ActionResult> Index()
        {
            if (!await AuthorizePage("MyCard"))
                return RedirectToAction("NoAccess", "Home");

            OmniDataItemManager mgr;
            OmniDataItemMock injector = new OmniDataItemMock();
            mgr = new OmniDataItemManager(injector);
            mgr.LoadCardDetails();
            return View(mgr);
        }
    }
}