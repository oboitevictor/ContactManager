using Contact.Core.DataAccess;
<<<<<<< HEAD
using Contact.Core.Interfaces.IManagers;
=======
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Managers
{
<<<<<<< HEAD
    public class RoleManager : IRoleManager
=======
    public class RoleManager
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
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
<<<<<<< HEAD
                operation.Message = ex.Message;
            }
            return operation;
        }
        public Operation CreateRole(RoleModel model)
        {
            var operation = new Operation();

            try
            {
                var role = _db.Get<Role>().Where(x => x.Name == model.Name).ToList();
                if(role.Any())
                {
                    throw new Exception("Role with this name already Exist");
                }
                else
                {
                    var roleItem = new Role();
                    roleItem.Name = model.Name;
                    roleItem.Description = model.Description;
                    _db.Add(roleItem);
                    _db.SaveChanges();
                    operation.Status=StatusCode.Succeeded;
                }
            }
            catch (Exception)
            {
                operation.Status = StatusCode.Succeeded; 
                throw;
            }
            return operation;
        }
        public Role GetRoleByName(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return new Role();
            }
            else
            {
                var query = _db.Get<Role>().Where(x => x.Name == roleName).FirstOrDefault();
                return query;
            }
        }
        public IEnumerable<Role> GetAllRole()
        {
            var query = _db.Get<Role>().ToList();
            if (query == null)
            {
                return new List<Role>();
            }
            else
            {
                return query;
            }
        }
        public Operation Delete(int id)
        {
            var operation = new Operation();
            try
            {
                var role = _db.GetByID<Role>(id);
                if (role != null)
                {
                    _db.Delete(role);
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return operation;
        }
        public bool AssignRoleToUser(int userID, int roleID)
        {
            try
            {
                var rolemodel = _db.Get<Role>().Where(x => x.RoleID == roleID).FirstOrDefault();
                if (rolemodel == null)
                {
                    throw new Exception("Role Can Not Be NUll");
                }
                var usermodel = _db.Get<User>().FirstOrDefault(x => x.UserID == userID);
                if (usermodel == null)
                {
                    throw new ArgumentException("User Is Null");
                }
                var model = new UserRole();
                model.UserID = usermodel.UserID;
                model.RoleID = rolemodel.RoleID;
                model.Role = rolemodel;
                _db.Add(model);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Role GetRoleByID(int id)
        {
            var query = _db.GetByID<Role>(id);
            if(query==null)
            {
                return new Role();
            }
            else
            {
                return query;
            }
        }
        public Operation EditRole( int id, RoleModel model)
        {
            var operation = new Operation();

            var role = _db.GetByID<Role>(id);
            role.Name = model.Name;
            role.Description = model.Description;
            _db.Update(role);
            _db.SaveChanges();
            return operation;
        }
       
        public bool IsUserInRole(string email, string roleName)
        {
            var user = _db.Get<User>().SingleOrDefault(x => x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
            var roles = from ur in user.UserRoles
                        from r in _db.Get<Role>()
                        where ur.Role.RoleID == r.RoleID
                        select r.Name;
            if (user != null)
                return roles.Any(r => r.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            else
                return false;
        }
        public string[] GetRoleForUser(string email)
        {
            var user = _db.Get<User>().SingleOrDefault(x => x.Email == email);
            if (user == null)
            {
                return new string[] { };
            }
            else
            {
                return user.UserRoles == null ? new string[] { } : user.UserRoles.Select(u => u.Role).Select(u => u.Name).ToArray();
            }
        }
=======
                operation.Catch(ex);
            }
            return operation;
        }
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
    }
}
