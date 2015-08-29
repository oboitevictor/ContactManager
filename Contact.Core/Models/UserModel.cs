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
<<<<<<< HEAD
        public virtual string Email { get; set; }
=======
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf

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
<<<<<<< HEAD
                Email = Email,
                Username=UserName
=======
                Email = UserName,
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
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
