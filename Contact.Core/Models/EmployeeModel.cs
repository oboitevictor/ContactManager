using Contact.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact.Core.Models
{
   public class EmployeeModel:Model
    {
        public int UserID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int DeptID { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual User User { get; set; }
        public virtual Byte[] ImageData { get; set;}
        public string Sex { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string ReportingTo { get; set; }
        public string Designation { get; set; }
        public Nullable<int> BranchID { get; set; }
        public string Address2 { get; set; }
        public Nullable<System.DateTime> EmploymentDate { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public virtual DepartmentModel Department { get; set; }
       public EmployeeModel()
        {
            User = new User();
            Department = new DepartmentModel();
        }
       public EmployeeModel(Employee emp)
       {
           Map(emp);
       }

       private EmployeeModel Map(Employee emp)
       {
           this.Assign(emp);
           return this;
       }
       public Employee create()
       {
           return new Employee
           {
                UserID=UserID,
                //Department=Department,
                FirstName=FirstName,
                LastName=LastName,
                DeptID=DeptID,
                User=User   
           };
       }
    }
}
