using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Web.Areas.Admin.Models
{
    public class EmployeeViewModel:EmployeeModel
    {
            public override string FirstName { get; set; }
            public override string LastName { get; set; }

            //[Required(ErrorMessage = "Email is Requirde")]
            //[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            //                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            //                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            //                    ErrorMessage = "Email is not valid")]
            public override string EmailAddress { get; set; }
            public byte[] Image { get; set; }
            public IEnumerable<DepartmentModel> Departments { get; set; }
            public  EmployeeViewModel()
            {
                Initializer();
            }
            public EmployeeViewModel(EmployeeModel model)
            {
                Initializer();
                this.Assign(model);
            }
            private void Initializer()
            {
                Departments = new List<DepartmentModel>();
            }
        }
}
