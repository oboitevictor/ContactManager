using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contact.Web.Controllers
{
<<<<<<< HEAD
=======
    [Authorize(Roles = "ViewHome")]
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}