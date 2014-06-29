using Contact.Core.DataAccess;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Managers
{
    public class UserManager
    {
        private DataRepository _db;
       
        public UserManager(DataRepository db)
        {
            _db = db;
        }


        public Operation Validate(UserModel model)
        {
          
            var operation = new Operation();
            try
            {
                var isValid = _db.Get<User>().Any(u => u.Email == model.UserName && u.Password == model.Password);
                operation.Status = isValid ? StatusCode.Succeeded : StatusCode.Failed;
                operation.Message = isValid ? "User is valid" : "Invalid Username or Password";
            }
            catch (Exception ex)
            {
                operation.Catch(ex);
            }
            return operation;
        }

        public Operation CreateUser(UserModel model)
        {
            var operation = new Operation();
            try
            {
                //Check to see if the user already exists
                var exists = _db.Get<User>().Any(u => u.Email == model.UserName);
                if (exists)
                {
                    operation.Status = StatusCode.Failed;
                    operation.Message = "User already exists";
                }
                else
                {
                 
                    //Create user
                    var user = model.Create();
                    user.UserID = user.UserID;
                    user.Email = user.Email;
                    user.Password = user.Password;
                    
                    _db.Add(user);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                operation.Catch(ex);
            }
            return operation;
        }

        public Operation DeleteUser(int id)
        {
            var operation = new Operation();
            var user = _db.GetByID<User>(id);
            if (user != null)
            {
                _db.Delete(user);
                _db.SaveChanges();
            }
            else
            {
                operation.Status = StatusCode.Failed;
                operation.Message = "unable to delete record";
            }
            return operation;
        }
         public Operation updateUser (UserModel model)
        {
            var operation = new Operation();
            var user = _db.GetByID<User>(model.UserID);
             if(user != null)
             {
                 model.update(user);
              return  _db.SaveChanges();
             }
             else
             {
                 operation.Status = StatusCode.Failed;
                 operation.Message = "user not updated";
             }
             return operation;
        }
      
    }
}
