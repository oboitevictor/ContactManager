using Contact.Core.DataAccess;
using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contact.Web.Areas.Admin.Models
{
    public class RoleViewModel:RoleModel
    {
        public string user { get; set; }
        public string role { get; set; }
        public IEnumerable<User> users { get; set; }
        public IEnumerable<Contact.Core.DataAccess.Role> roles { get; set; }

    }
}