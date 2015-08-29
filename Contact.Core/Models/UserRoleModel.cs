using Contact.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
  public  class UserRoleModel:Model
    {
        public virtual int UserID { get; set; }
        public virtual int RoleID { get; set; }
      public UserRoleModel()
        {

        }
      public UserRoleModel(UserRole userRole)
      {
          Map(userRole);
      }

      private UserRoleModel Map(UserRole userRole)
      {
          this.UserID = userRole.UserID;
          this.RoleID = userRole.RoleID;
          return this;
      }

    }
}
