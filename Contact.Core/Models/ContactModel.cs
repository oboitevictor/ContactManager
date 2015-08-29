using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
    public class ContactModel : Model
    {
        public virtual string Name { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Address { get; set; }

        public ContactModel(Contact.Core.DataAccess.Contact model)
        {
            Map(model);
        }
        public Contact.Core.DataAccess.Contact Create()
        {
            return new Contact.Core.DataAccess.Contact
            {
                Address = Address,
                EmailAddress = EmailAddress,
                Name = Name,
                PhoneNumber = PhoneNumber
            };
        }
        public ContactModel()
        {

        }
        private ContactModel Map(DataAccess.Contact model)
        {
            Name = model.Name;
            PhoneNumber = model.PhoneNumber;
            EmailAddress = model.EmailAddress;
            Address = model.Address;
            return this;
        }
    }
}
