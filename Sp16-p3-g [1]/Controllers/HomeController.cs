using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sp16_p3_g__1_.Controllers
{
    public class HomeController : Controller
    {
        // [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}