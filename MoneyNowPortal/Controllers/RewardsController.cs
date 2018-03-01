using OmniDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MoneyNowPortal.Controllers
{
    public class RewardsController : BaseController
    {
        // GET: Rewards
        public async Task<ActionResult> Index()
        {
            if (!await AuthorizePage("MyRewards"))
                return RedirectToAction("NoAccess", "Home"); 

            OmniDataItemManager mgr;
            OmniDataItemMock injector = new OmniDataItemMock();
            mgr = new OmniDataItemManager(injector);
            mgr.LoadCardDetails();

            ViewBag.TotalCardRewards = mgr.CardDetailsList.Sum(r => r.totalCardPoints);

            return View(mgr);
        }
    }
}