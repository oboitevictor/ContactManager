using DataAccess = Contact.Core.DataAccess;
using Contact.Core.Managers;
using Contact.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Contact.Web.Controllers
{
    public class AccountController : WebController
    {
        private UserManager _user;
        public AccountController()
        {
            var db = new DataAccess.DataRepository(new DataAccess.DataEntities());
            _user = new UserManager(db);
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model, string ReturnUrl)
        {
            var validateUser = _user.Validate(model);
            if (validateUser.Status == StatusCode.Succeeded)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return Redirect(ReturnUrl);
            }
            else
            {
                Error(validateUser.Message);
            }

            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            return Redirect(ReturnUrl);

            //return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}