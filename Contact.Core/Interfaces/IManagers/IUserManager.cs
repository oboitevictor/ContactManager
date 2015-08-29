using Contact.Core.DataAccess;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Interfaces.IManagers
{
   public interface IUserManager
    {
     Operation Validate(UserModel model);
     Operation CreateUser(UserModel model);
     Operation DeleteUser(int id);

     Operation updateUser (UserModel model);

     Operation EdithUser(int id);
     UserModel GetUserByID(int id);
     IEnumerable<User> GetAllUsers();
     Operation<UserModel> GetUser(string username);
     Operation ChangePassword(int userID, string oldPassword, string newpassword);

    }
}
