using Contact.Core.DataAccess;
using Contact.Core.Interfaces.IManagers;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Managers
{
    public class DepartmentManager : IDepartmentManager
    {
       private DataRepository _db;

       public DepartmentManager(DataRepository db)
       {
           _db = db;
       }
       public  Operation CreateDepartment(DepartmentModel dept)
       {
           var operation = new Operation();
           try
           {
               //Check to see if the Department already exists
               var exists = _db.Get<Department>().Any(u => u.Name==dept.Name);
               if (exists)
               {
                   operation.Status = StatusCode.Failed;
                   operation.Message = "Department already exists";
               }
               else
               {

                   //Create departmentbn
                   var user = dept.CreateDept();
                  _db.Add(user);
                  _db.SaveChanges();
               }
           }
           catch (Exception ex)
           {
               operation.Message = ex.Message;
           }
           return operation;
       }
       public Operation Edit(int id, DepartmentModel model)
       {
           var operation = new Operation();
           try
           {
               var dept = _db.Get<Department>().Where(x => x.DeptID == id).FirstOrDefault();
               if (dept != null)
               {
                   dept.Name=model.Name;
                   dept.Description=model.Description;
                  _db.Update(dept);
                  _db.SaveChanges();
               }
           }
           catch (Exception)
           {
               operation.Status = StatusCode.Failed;
               throw;
           }
           return operation;
       }

       public IEnumerable<Department> GetDept()
       {
          var dept = _db.Get<Department>().ToList();
          return dept;
           //var model = new List<DepartmentModel>();
       }
       public IEnumerable<DepartmentModel> GetDepartments()
       {
           var dept = _db.Get<Department>().ToList().Select(s => new DepartmentModel(s));
           return dept;
       }
       public DepartmentModel GetDeptByID(int id)
       {
           var query = _db.GetByID<Department>(id);
           if(query==null)
           {
               return new DepartmentModel();
           }
           var dept = new DepartmentModel();
           dept.DeptID = query.DeptID;
           dept.Name = query.Name;
           dept.Description = query.Description;
           return dept;
       }
       public Operation Delete(int id)
       {
           var operation = new Operation();
           var dept = _db.GetByID<Department>(id);
           if (dept != null)
           {
               _db.Delete(dept);
               _db.SaveChanges();
           }
           else
           {
               operation.Status = StatusCode.Failed;
               operation.Message = "unable to delete record";
           }
           return operation;
       }
       public IEnumerable<Department> GetAllDepartment()
       {
           return _db.Get<Department>().ToList();
       }
    }
}
