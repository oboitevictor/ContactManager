using Contact.Core.Interfaces.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Managers
{
   public class Manager:IManager
    {
       public IUserManager User { get; private set; }
       public IRoleManager Role { get; private set; }
       public IDepartmentManager Dept { get; private set; }
       public IEmployeeManager Emp { get; private set; }
       public IContactManager Contact { get; private set; }
       public IBranchManager Branch { get; private set; }
       public Manager(IUserManager user, IRoleManager role, IDepartmentManager dept, IEmployeeManager emp, IContactManager contact, IBranchManager branch)
       {
           User = user;
           Role = role;
           Dept = dept;
           Emp = emp;
           Contact = contact;
           Branch = branch;
           
       }
    }
}
