using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contact.Web.Models
{
    public class User : UserModel
    {
        public override string Email { get; set; }
        public string RetypeEmail { get; set; }
        public override string UserName { get; set; }
        public override string Password { get; set; }
        public bool RememberMe { get; set; }

        public User()
        {

        }

        public User(UserModel user)
        {
            this.UserName = user.UserName;
            this.Password = user.Password;
        }

      
    }
}