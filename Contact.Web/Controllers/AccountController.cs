using DataAccess = Contact.Core.DataAccess;
using Contact.Core.Managers;
using Contact.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
<<<<<<< HEAD
using Contact.Core.Interfaces.IManagers;
=======
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf

namespace Contact.Web.Controllers
{
    public class AccountController : WebController
    {
<<<<<<< HEAD
        private IUserManager _user;
        public AccountController(IManager manager)
        {

            _user = manager.User;
        }
=======
        private UserManager _user;
        public AccountController()
        {
            var db = new DataAccess.DataRepository(new DataAccess.DataEntities());
            _user = new UserManager(db);
        }

>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
<<<<<<< HEAD
        [HttpPost]
        public ActionResult Login(User model, string ReturnUrl)
=======

        [HttpPost]
        public ActionResult Login(UserViewModel model, string ReturnUrl)
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
        {
            var validateUser = _user.Validate(model);
            if (validateUser.Status == StatusCode.Succeeded)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
<<<<<<< HEAD
                return RedirectToAction("Index", "User");
=======
                return Redirect(ReturnUrl);
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
            }
            else
            {
                Error(validateUser.Message);
            }

            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            return Redirect(ReturnUrl);

            //return View(model);
        }
<<<<<<< HEAD
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
=======

        public ActionResult Logout()
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
<<<<<<< HEAD
        
=======
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
    }
}