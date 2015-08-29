using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contact.Web.Models
{
    public class UserViewModel : UserModel
    {
        [Required]
        public override string UserName { get; set; }
        [Required]
        public override string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }

        public UserViewModel()
        {
            InInitializer();
        }

       public UserViewModel InInitializer()
        {
            throw new NotImplementedException();
        }
    }
}