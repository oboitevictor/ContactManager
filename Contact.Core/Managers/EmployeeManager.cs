using Contact.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Contact.Core.Models;
using Contact.Core.Interfaces.IManagers;
namespace Contact.Core.Managers
{
   public class EmployeeManager:IEmployeeManager
    {
       private DataRepository _db;
       public EmployeeManager(DataRepository db)
       {
           _db = db;
       }
      
       public IEnumerable<Employee> GetEmployeeByName(string name)
       {
           IEnumerable<Employee> Result = null;
           if (string.IsNullOrEmpty(name))
           {
               //.Include("Department").Include("User")
               Result = _db.Get<Employee>().Include("Department").Include("User").ToList();//.Select(s => new EmployeeModel(s));
               return Result;
           }
           Result = _db.Get<Employee>().Where(x => x.FirstName.Contains(name)).Include("Department").Include("User").ToList();//Select(s => new EmployeeModel(s));
           return Result;
       }
       public Employee  GetEmployeeByID(int id)
       {
           var emp = _db.GetByID<Employee>(id);
           return emp;
       }

     public  IEnumerable<Employee> GetAllEmployee()
       {
           var emp = _db.Get<Employee>().ToList();
           return emp;
       }
     
       public Operation createEmployee(EmployeeModel model, Byte[] data)
       {
            var operation = new Operation();
            try
            {
                //Check to see if the user already exists
                var exists = _db.Get<Employee>().Any(u => u.UserID == model.UserID);
                if (exists)
                {
                    operation.Status = StatusCode.Failed;
                    operation.Message = "User already exists";
                }
                else
                {
                    //Create employee
                    var getuser = _db.Get<User>().Where(x =>x.Email==model.EmailAddress).FirstOrDefault();
                    //var dept = _db.Get<Department>().whet
                    if (getuser != null)
                    {
                        var emp = model.create();
                        emp.FirstName = model.FirstName;
                        emp.LastName = model.LastName;
                        emp.Address = model.Address;
                        emp.CountryID = model.CountryID;
                        emp.BranchID = model.BranchID;
                        emp.Address2 = model.Address2;
                        emp.StateID = model.StateID;
                        emp.ReportingTo = model.ReportingTo;
                        emp.Sex = model.Sex;
                        emp.EmploymentDate = model.EmploymentDate;
                        emp.DateOfBirth = model.DateOfBirth;
                        emp.User = getuser;
                        emp.UserID = getuser.UserID;
                        emp.DeptID = model.DeptID;
                        emp.IMageData = data;
                        _db.Add(emp);
                      _db.SaveChanges();
                      operation.Status = StatusCode.Succeeded;
                    }
                    else
                    {
                        throw new Exception("User With this Email does not exist");
                    }
                }
            }
            catch (Exception)
            {
                operation.Status = StatusCode.Failed;
                throw;
            }
            return operation;
       }
    }
}
