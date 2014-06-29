using Contact.Core.DataAccess;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Managers
{
    public class RoleManager
    {
        private DataRepository _db;
        public RoleManager(DataRepository db)
        {
            _db = db;
        }

        public Operation<PermissionModel[]> GetUserRoles(string username)
        {
            var operation = new Operation<PermissionModel[]>();
            try
            {
                var query = from userroles in _db.Get<UserRole>()
                            join roleperm in _db.Get<RolePermission>()
                            on userroles.RoleID equals roleperm.RoleID
                            where userroles.User.Email == username
                            select roleperm.Permission;
                operation.Result = query.ToList().Select(p => new PermissionModel(p)).ToArray();
                operation.Status = StatusCode.Succeeded;
            }
            catch (Exception ex)
            {
                operation.Catch(ex);
            }
            return operation;
        }
    }
}
