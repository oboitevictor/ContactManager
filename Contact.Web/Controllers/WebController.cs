using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contact.Web.Controllers
{
    public abstract class WebController : Controller
    {
        public void Error(string message)
        {
            TempData["Message"] = message;
            TempData["Status"] = "Error";
        }
        public void Success(string message)
        {
            TempData["Message"] = message;
            TempData["Status"] = "Success";
        }
    }
}