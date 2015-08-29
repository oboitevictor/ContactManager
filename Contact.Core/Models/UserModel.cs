using Contact.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
    public class UserModel:Model
    {
        public int UserID { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }

        public virtual ICollection<RoleModel> Roles { get; set; }

        public UserModel()
        {
            Roles = new List<RoleModel>();
        }

        public UserModel(User user)
        {
            Map(user);
        }

        public UserModel Map(User user)
        {
            this.Assign(user);
            this.UserName = user.Email;
            return this;
        }

        public User Create()
        {
            return new User
            {
                Password = Password,
                UserID = UserID,
                Email = Email,
                Username=UserName
            };
        }
        public void update(User users)
        {
            this.Password = users.Password;
            this.UserName = users.Email;

        }
        //public User delete()
        //{

        //}
    }
}
