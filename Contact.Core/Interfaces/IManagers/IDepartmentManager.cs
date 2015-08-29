using Contact.Core.DataAccess;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Interfaces.IManagers
{
 public interface IDepartmentManager
    {
      Operation CreateDepartment(DepartmentModel dept);
      Operation Edit(int id, DepartmentModel model);
      IEnumerable<Department> GetDept();
      IEnumerable<DepartmentModel> GetDepartments();
      DepartmentModel GetDeptByID(int id);
      Operation Delete(int id);
      IEnumerable<Department> GetAllDepartment();

    }
}
