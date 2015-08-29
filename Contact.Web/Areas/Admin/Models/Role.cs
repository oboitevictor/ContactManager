using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Web.Areas.Admin.Models
{
   public class Role:RoleModel
    {
        public override string Name { get; set; }
        public override string Description { get; set; }

       public Role()
        {

        }
       public Role(RoleModel model)
        {
            this.Name = model.Name;
            this.Description = model.Description;
        }
    }
}
