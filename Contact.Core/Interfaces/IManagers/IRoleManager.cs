using Contact.Core.DataAccess;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Interfaces.IManagers
{
   public interface IRoleManager
    {
       Operation<PermissionModel[]> GetUserRoles(string username);
       Operation CreateRole(RoleModel model);
       Role GetRoleByName(string roleName);
       IEnumerable<Role> GetAllRole();
       bool AssignRoleToUser(int user, int role);
       bool IsUserInRole(string email, string roleName);
       string[] GetRoleForUser(string email);
       Role GetRoleByID(int id);
       Operation EditRole(int id, RoleModel model);
       Operation Delete(int id);
    }
}
