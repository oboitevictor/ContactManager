using Contact.Core.DataAccess;
using Contact.Core.Interfaces.IManagers;
using Contact.Core.Managers;
using Contact.Web.Areas.Admin.Models;
using Contact.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contact.Web.Areas.Admin.Controllers
{
    public class BranchController : WebController
    {
        private readonly IBranchManager _branch;

        public BranchController(IManager manager)
        {
            _branch = manager.Branch;
        }
        // GET: Admin/Branch
        public ActionResult Index()
        {
            var branches = _branch.GetListOfBranch();
            return View(branches);
        }
        [HttpGet]
        public ActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBranch(Contact.Web.Areas.Admin.Models.Branch model)
        {
            try
            {
                var create = _branch.CreateBranch(model);
                if (create.Status == StatusCode.Succeeded)
                {
                    Success("Branch Created Successfully");
                }
                else
                {
                    Error("Failed to Create Branch");
                    create.Status = StatusCode.Failed;
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return View();
            }
        }
        public ActionResult EditBranch(int id, Contact.Web.Areas.Admin.Models.Branch model)
        {
           var operation = _branch.EditBranch(id, model);
            if(operation.Status==StatusCode.Succeeded)
            {
                Success("Edited Successfully");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var operation = _branch.DeleteBranch(id);
                if (operation.Status == StatusCode.Succeeded)
                {
                    Success(string.Format("Branch with Id:{0} is deleted", id));
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
            
        }
    }
}