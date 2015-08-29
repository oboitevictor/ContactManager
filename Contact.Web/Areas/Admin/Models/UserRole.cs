using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Web.Areas.Admin.Models
{
   public class UserRole:UserRoleModel
    {
       public override int UserID { get; set;}
       public override int RoleID { get; set;}
    }
}
