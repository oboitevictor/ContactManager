using Contact.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
    public class PermissionModel : Model
    {
        public int PermissionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PermissionModel()
        {

        }

        public PermissionModel(Permission entity)
        {
            Map(entity);
        }

        public PermissionModel Map(Permission entity)
        {
            this.Assign(entity);
            return this;
        }
    }
}
