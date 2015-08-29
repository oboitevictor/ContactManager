using Contact.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
   public class DepartmentModel:Model
    {
        public int DeptID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<EmployeeModel> Employees { get; set; }

       public DepartmentModel()
        {
            Employees = new List<EmployeeModel>();
        }
       public DepartmentModel(Department model)
       {
           Map(model);
       }

       private DepartmentModel Map(Department model)
       {
           this.Assign(model);
           this.Name = model.Name;
           return this;
       }

       public Department CreateDept()
       {
           return new Department
           {
            DeptID=DeptID,
            Name= Name,
            Description=Description
           };
       }
    }
}
