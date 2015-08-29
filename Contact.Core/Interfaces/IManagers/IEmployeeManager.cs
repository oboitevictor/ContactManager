using Contact.Core.DataAccess;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Interfaces.IManagers
{
   public interface IEmployeeManager
    {
       IEnumerable<Employee> GetEmployeeByName(string name);
       Operation createEmployee(EmployeeModel model, Byte[] data);
       Employee GetEmployeeByID(int id);
       IEnumerable<Employee> GetAllEmployee();
    }
}
