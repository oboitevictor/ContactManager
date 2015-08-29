using Contact.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
    public class RoleModel : Model
    {

        public int RoleID { get; set; }
<<<<<<< HEAD
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
=======
        public string Name { get; set; }
        public string Description { get; set; }
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf

        public RoleModel()
        {

        }

        public RoleModel(Role entity)
        {
            Map(entity);
        }

        public RoleModel Map(Role entity)
        {
            RoleID = entity.RoleID;
            Name = entity.Name;
            Description = entity.Description;
            return this;
        }

        public virtual ICollection<PermissionModel> Permissions { get; set; }
    }
}
