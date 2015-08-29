using Contact.Core.Interfaces.IManagers;
using Contact.Web.Areas.Admin.Models;
using Contact.Web.Controllers;
using Contact.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Contact.Web.Areas.Admin.Controllers
{
    
   
    public class RoleController : WebController
    {
        private readonly IRoleManager _role;
        private readonly IUserManager _user;
        public RoleController(IManager manager)
        {
            _role = manager.Role;
            _user = manager.User;
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            var role = _role.GetAllRole();
            return View(role);
        }

        // GET: Admin/Role/Details/5
        public ActionResult Details(int id)
        {
            var query = _role.GetRoleByID(id);
            return View(query);
        }

        // GET: Admin/Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Role/Create
        [HttpPost]
        public ActionResult Create(Role model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var role = new Role();
                    role.Name = model.Name;
                    role.Description = model.Description;
                   _role.CreateRole(role);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Role/Edit/5
        public ActionResult Edit(int id)
        {
            var query = _role.GetRoleByID(id);
            return View(query);
        }

        // POST: Admin/Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Role model)
        {
            try
            {
                if(model!=null)
                {
                    _role.EditRole(id, model);
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Role/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        [HttpGet]
        public ActionResult AssignRole()
        {
            var roleViewModel = new RoleViewModel();
            ViewBag.users = _user.GetAllUsers().Select(x => new SelectListItem { Selected = false, Text = x.Username, Value = x.UserID.ToString() });
            ViewBag.roles = _role.GetAllRole().Select(x => new SelectListItem { Selected = false, Text = x.Name, Value = x.RoleID.ToString() });
            
            return View(roleViewModel);
        }
        [HttpPost]
        public ActionResult AssignRole(RoleViewModel model)
        {

           var assign =_role.AssignRoleToUser(Convert.ToInt32(model.user), Convert.ToInt32(model.role));
            if(assign)
            {
                Success("Role Assign Successfully");
            }
            else
            {
                Error("Failed To assign Role");
            }
            
            return View("Index");
        }
    }
}
