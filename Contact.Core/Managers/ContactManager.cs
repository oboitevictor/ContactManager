using Contact.Core.Interfaces.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Core.DataAccess;
using Contact.Core.Interfaces;
using Contact.Core.Models;

namespace Contact.Core.Managers
{
    public class ContactManager : IContactManager
    {
        private readonly DataRepository _db;
        public ContactManager(DataRepository db)
        {
            _db = db;
        }
        public  async Task<int> CreateContactAsync(Models.ContactModel contact)
        {
            var get = _db.Get<Contact.Core.DataAccess.Contact>().Where(x => x.EmailAddress == contact.EmailAddress).FirstOrDefault();
            if (get != null)
            {
                throw new Exception("Contact Already Exist");
            }

            var creat = contact.Create();
            _db.Add(creat);
          return  await _db.SaveChangesAsync();   
        }
      public  ContactModel GetContactByID(int id)
        {
            var contact = _db.GetByID<Contact.Core.DataAccess.Contact>(id);
            return new ContactModel(contact);
        }

        public async Task<ContactModel> EditContactAsync(ContactModel model)
        {
            var contact = _db.Get<Contact.Core.DataAccess.Contact>().Where(x => x.EmailAddress == model.EmailAddress || x.PhoneNumber == model.PhoneNumber).FirstOrDefault();
            if(contact!=null)
            {
                contact.EmailAddress = model.EmailAddress;
                contact.PhoneNumber = model.PhoneNumber;
                contact.Name = model.Name;
                contact.Address = model.Address;
            }
          int result = await _db.SaveChangesAsync();
         // if (result > 0)
           return new ContactModel(contact);
        }

        public IEnumerable<Models.ContactModel> GetAllContact()
        {
            var query = _db.Get<Contact.Core.DataAccess.Contact>().Select(s => new ContactModel(s));
            return query;
        }

        public async Task<ContactModel> DeleteContact(int id)
        {
            Contact.Core.DataAccess.Contact contact = null;
            if(id>0)
            {
                contact = _db.GetByID<Contact.Core.DataAccess.Contact>(id);
                if(contact!=null)
                {
                    _db.Delete(contact);
                 await _db.SaveChangesAsync();
                }
            }
            return new ContactModel(contact);
        }
    }
}
