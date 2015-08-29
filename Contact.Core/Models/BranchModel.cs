using Contact.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
    public class BranchModel : Model
    {
        public virtual string BranchName { get; set; }
        public virtual string BranchAddress { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string PhoneNumber { get; set; }

        public virtual IList<EmployeeModel> Employees { get; set; }

        public BranchModel()
        {
            Employees = new List<EmployeeModel>();
        }
        public BranchModel(Branch model)
        {
            Map(model);
        }

        private BranchModel Map(Branch model)
        {
            this.Assign(model);
            return this;
        }
    }
}
