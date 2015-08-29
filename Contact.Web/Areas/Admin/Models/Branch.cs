using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Web.Areas.Admin.Models
{
   public class Branch:BranchModel
    {
        public override string BranchName { get; set; }
        public override string BranchAddress { get; set; }
        public override string EmailAddress { get; set; }
        public override string PhoneNumber { get; set; }
   
    }
}
