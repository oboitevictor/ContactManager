using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Interfaces.IManagers
{
   public interface IManager
    {
       IUserManager User { get; }
       IRoleManager Role { get; }
       IDepartmentManager Dept { get;}
       IEmployeeManager Emp { get; }
       IContactManager Contact { get; }
       IBranchManager Branch { get; }

    }
}
