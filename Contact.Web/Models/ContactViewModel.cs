using Contact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Web.Models
{
   public class ContactViewModel:ContactModel
    {
        public override string Name { get; set; }
        public override string PhoneNumber { get; set; }
        public override string EmailAddress { get; set; }
        public override string Address { get; set; }

       public ContactViewModel(ContactModel model)
       {
           this.Name = model.Name;
           this.PhoneNumber = model.PhoneNumber;
           this.EmailAddress = model.EmailAddress;
           this.Address = model.Address;
          
       }
    }
}
