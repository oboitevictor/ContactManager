using DataAccess = Contact.Core.DataAccess;
using Contact.Core.Managers;
using Contact.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contact.Core.Models;
using Contact.Core.Interfaces.IManagers;
using Contact.Core.DataAccess;

namespace Contact.Web.Controllers
{
    public class UserController : WebController
    {
        public int pageSize = 10;
        //private readonly IUserManager _user;
        //public UserController(IManager Manager)
        //{
        //    _user = Manager.User;
        //}
        private readonly UserManager _user;
        public UserController()
        {
            var db = new DataRepository(new DataEntities());
            _user = new UserManager(db);
        }
        // GET: /User/
        public ActionResult Index(int page =1)
        {
         
            //var user = new List<User>();
            var query = _user.GetAllUsers();
            if (query != null)
            {
                return View(query.ToList().OrderBy(x=>x.UserID).Skip((page-1*pageSize)).Take(pageSize));
            }
            else
            {
                return View();
            }
        }
        // GET: /User/Details/5
        public ActionResult Details(int id)
        {
            var query = _user.GetUserByID(id);
            Contact.Web.Models.User user = new Contact.Web.Models.User();
            if (query != null)
            {
                user.UserName = query.UserName;
                user.Password = query.Password;
                user.Email = query.Email;
            }
            return View(user);
        }

        [HttpGet]
        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create
        [HttpPost]
        public ActionResult Create(Contact.Web.Models.User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Email != model.RetypeEmail)
                    {
                        Error("Email are Not Equal");
                    }
                    else
                    {
                        _user.CreateUser(model);
                    }
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("oops", "unable to save changes to database try again");
                return View(model);
            }
        }

        //
        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            
            
            return View();
        }

        //
        // POST: /User/Edit/5
           [HttpPost]    
        public ActionResult Edit( int id , UserModel model )
        {
            try
            {
                if(ModelState.IsValid)
                {
                     _user.updateUser(model);

                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        // GET: /User/Delete/5
        public ActionResult Delete(int id)
        {
            var query = _user.GetUserByID(id);
            return View(query);
        }

        //
        // POST: /User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserModel model )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _user.DeleteUser(id);

                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        //public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        //{
        //    return Json(new
        //    {
        //        sEcho = param.sEcho,
        //        iTotalRecords = 97,
        //        iTotalDisplayRecords = 3,
        //        aaData = _user.GetAllUsers()
        //    },
        //    JsonRequestBehavior.AllowGet);
        //}
    }
}
