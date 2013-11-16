using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDualLoginDemo.Controllers
{
    [Authorize]
    public class StatusController : Controller
    {
        //
        // GET: /Status/

        public ActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;
            return View();
        }

    }
}
