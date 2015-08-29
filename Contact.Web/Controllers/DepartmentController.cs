using Contact.Core.DataAccess;
using Contact.Core.Interfaces.IManagers;
using Contact.Core.Managers;
using Contact.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contact.Web.Controllers
{
    public class DepartmentController : Controller
    {
       // private readonly IDepartmentManager _dept;
        private readonly DepartmentManager _dept;
        //public DepartmentController(IManager manager)
        //{
        //    _dept = manager.Dept;
        //}
        public DepartmentController()
        {
            var db = new DataRepository(new DataEntities());
            _dept = new DepartmentManager(db);
        }
        // GET: Department
        public ActionResult Index()
        {
            var query = _dept.GetDept();
            return View(query);
        }
         [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
         {
             var query = _dept.GetDeptByID(id);
             Contact.Web.Models.Department dept = new Contact.Web.Models.Department();
             if (query != null)
             {
                 dept.DeptID = query.DeptID;
                 dept.Name = query.Name;
                 dept.Description = query.Description;
             }
             return View(dept);
         }
        [HttpPost]
        public ActionResult Create(Contact.Web.Models.Department model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dept.CreateDepartment(model);

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
        [HttpPut]
        public ActionResult Edit(int id)
        {
            var query = _dept.GetDeptByID(id);
            return View(query);
        }
        public ActionResult Edit(int id, Contact.Web.Models.Department model)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    var query = _dept.Edit(id, model);
                    query.Status = StatusCode.Succeeded;
                 
                }
                return RedirectToAction("Index");
                // TODO: Add update logic here
            }
            catch
            {
                return View(model);
            }
        }
        public ActionResult Delete(int id)
        {
            var query = _dept.GetDeptByID(id);
            var dept = new Contact.Web.Models.Department();
            dept.DeptID = query.DeptID;
            dept.Name = query.Name;
            dept.Description = query.Description;
            return View(dept);
        }

        //
        // POST: /User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Contact.Web.Models.Department model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _dept.Delete(id);
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}