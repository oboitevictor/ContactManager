using Contact.Core.DataAccess;
using Contact.Core.Interfaces.IManagers;
using Contact.Core.Models;
using Contact.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Managers
{
    public class UserManager : IUserManager
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
                var password = new HashingHelper().HashPassword(model.Password);
                var isValid = _db.Get<User>().Any(u => u.Email == model.UserName && u.Password ==password.ToString());
                operation.Status = isValid ? StatusCode.Succeeded : StatusCode.Failed;
                operation.Message = isValid ? "User is valid" : "Invalid Username or Password";
            }
            catch (Exception ex)
            {
                operation.Message = ex.Message;
            }
            return operation;
        }
        public Operation CreateUser(UserModel model)
        {
            var operation = new Operation();
            try
            {
                //Check to see if the user already exists
                var exists = _db.Get<User>().Any(u => u.Email == model.Email||u.Username==model.UserName);
                if (exists)
                {
                    operation.Status = StatusCode.Failed;
                    operation.Message = "User already exists";
                }
                else
                {
                    var password = new HashingHelper().HashPassword(model.Password);
                    //Create user
                    var user = model.Create();
                    user.UserID = user.UserID;
                    user.Email = user.Email;
                    user.Password = password.ToString();
                    _db.Add(user);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                operation.Message = ex.Message;
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

        public Operation EdithUser(int id)
         {
             var operation = new Operation();
           
           var user =  _db.GetByID<User>(id);
              _db.Update(user);

             _db.SaveChanges();

             return operation;
         }
       
        public UserModel GetUserByID(int id)
        {
            var model = new UserModel();
            var query = _db.GetByID<User>(id);
            model.UserName = query.Username;
            model.Email = query.Email;
            model.Password = query.Password;
            return model;
        }
      
        public IEnumerable<User> GetAllUsers()
        {

            var users = _db.Get<User>().ToList();
            return users;
           
        }

        public Operation ChangePassword(int userID, string oldPassword, string newpassword)
        {
            var operation = new Operation();
            try
            {
                //This is faster than querying as it first checks to see if has already has the record in memory
                var user = _db.GetByID<User>(userID);
                if (user != null)
                {
                    //Validate Password
                    var password = new HashingHelper().HashPassword(oldPassword);
                    if (user.Password == password.ToString())
                    {
                        //Change Password
                        var pass = new HashingHelper().HashPassword(newpassword);
                        user.Password = pass.ToString();
                        //Update is necessary for both API consistency and non-reliance on EF Tracking
                        _db.Update(user);
                        return _db.SaveChanges();
                    }
                    else
                    {
                        operation.Message = "Invalid Password";
                        operation.Status = StatusCode.Failed;
                    }
                }
                else
                {
                    operation.Status = StatusCode.Failed;
                    operation.Message = "User does not exist";
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                operation.Status = StatusCode.Failed;
                operation.Message = ex.Message;
            }
            return operation;
        }
        public Operation<UserModel> GetUser(string username)
        {
            var operation = new Operation<UserModel>();
            try
            {
                //Linq Lambda Syntax
                var user = _db.Get<User>().Where(s => s.Username == username).FirstOrDefault();
                if (user != null)
                {
                    operation.Result = new UserModel(user);     //Importance of Mapping: Use a single consitent line to easily convert entities to business Objects
                    operation.Status = StatusCode.Succeeded;
                    // Setting operation.Message is optional for successful operations
                }
                else
                {
                    operation.Status = StatusCode.Failed;
                    operation.Message = "Invalid UserName";
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                operation.Status = StatusCode.Succeeded;
                operation.Message = ex.Message;
            }
            return operation;
        }
    }
}
