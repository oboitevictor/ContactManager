using DataAccess = Contact.Core.DataAccess;
using Contact.Core.Managers;
using Contact.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Contact.Core.Interfaces.IManagers;

namespace Contact.Web.Controllers
{
    public class AccountController : WebController
    {
        private IUserManager _user;
        public AccountController(IManager manager)
        {

            _user = manager.User;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model, string ReturnUrl)
        {
            var validateUser = _user.Validate(model);
            if (validateUser.Status == StatusCode.Succeeded)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToAction("Index", "User");
            }
            else
            {
                Error(validateUser.Message);
            }

            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            return Redirect(ReturnUrl);

            //return View(model);
        }
        [Authorize]
        [ActionName("Profile")]         //The MVC Controller Class already has a property called Profile This annotation fixes that 
        public ActionResult UserProfile()
        {
            var getUser = _user.GetUser(User.Identity.Name);
            if (getUser.Status == StatusCode.Succeeded)
            {
                //Map Result into User ViewModel and pass that to the View
                var model = new User(getUser.Result);
                return View(model);
            }
            else
            {
                //User is Probably an Imposter. Logout the user
                return RedirectToAction("Logout");
            }
        }

        public JsonResult ChangePassword(string password, string newpassword)
        {
            var getUser = _user.GetUser(User.Identity.Name);
            if (getUser.Status ==StatusCode.Succeeded)
            {
                var user = getUser.Result;
                var changePassword = _user.ChangePassword(user.UserID, password, newpassword);
                return Json(changePassword);
            }
            else
            {
                return Json(getUser);
            }
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
        
    }
}