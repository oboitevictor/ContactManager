using Contact.Core.DataAccess;
using Contact.Core.Interfaces.IManagers;
using Contact.Core.Managers;
using Contact.Web.Areas.Admin.Models;
using Contact.Web.Controllers;
using Contact.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace Contact.Web.Areas.Admin.Controllers
{
    public class EmployeeController : WebController
    {
 
        private readonly IEmployeeManager _emp;
        private readonly IDepartmentManager _dept;
        public EmployeeController(IManager manager)
        {
            _emp = manager.Emp;
            _dept = manager.Dept;
        }
        // GET: Employee
        public ActionResult Index(string SearchString,int Page = 1, int PageSize = 10)
        {


            var employees = _emp.GetAllEmployee();

            if (!string.IsNullOrEmpty(SearchString))
            {
                employees = employees.Where(s => s.FirstName.ToUpper().Contains(SearchString.ToUpper()) || s.LastName.ToUpper().Contains(SearchString.ToUpper()));

            }
            PagedList<Employee> model = new PagedList<Employee>(employees, Page, PageSize);
            return View(model);
        }
        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var emp = _emp.GetEmployeeByID(id);
            return View(emp);
        }
        // GET: Employee/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Departments = _dept.GetDepartments().Select(x => new SelectListItem { Selected = false, Text = x.Name, Value = x.DeptID.ToString()});// new SelectList(model, "DeptID", "Name");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel emp, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        string pic = System.IO.Path.GetFileName(file.FileName);
                        string path = System.IO.Path.Combine(
                                               Server.MapPath("~/images/profile"), pic);
                        // file is uploaded
                        file.SaveAs(path);

                        // save the image path path to the database or you can send image
                        // directly to database
                        // in-case if you want to store byte[] ie. for DB
                        byte[] array = null;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);
                            array = ms.GetBuffer();
                        }


                        // after successfully uploading redirect the user
                        // return RedirectToAction("actionname", "controller name");
                        var create = _emp.createEmployee(emp, array);
                        if (create.Status == StatusCode.Succeeded)
                        {
                            Success("Employee Created Successfully");
                        }
                        else
                        {
                            Error("Failed To Create New Employee");
                            create.Status = StatusCode.Failed;
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }
    }
}
