using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyNowPortal.Controllers
{
    public class CardHolderController : Controller
    {      

        // GET: CardHolder - Home
        public ActionResult Home()
        {
            return View();
        }

        // GET: CardHolder - Group List
        public ActionResult GroupList()
        {
            return View();
        }
               
        // GET: CardHolder - List
        public ActionResult List()
        {
            return View();
        }
    }
}