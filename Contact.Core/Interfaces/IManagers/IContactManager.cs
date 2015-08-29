using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Core.DataAccess;
using Contact.Core.Models;

namespace Contact.Core.Interfaces.IManagers
{
   public interface IContactManager
    {
       Task<int> CreateContactAsync(ContactModel model);
       Task<ContactModel> EditContactAsync(ContactModel model);
       IEnumerable<ContactModel> GetAllContact();
       Task<ContactModel> DeleteContact(int id);
       ContactModel GetContactByID(int id);

    }
}
