using Contact.Core.Interfaces.IManagers;
using Contact.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using System.Threading.Tasks;

namespace Contact.Web.Controllers
{
    public class ContactsController : ApiController
    {
    //    private readonly IContactManager _contact;
    //    public ContactsController(IManager manager)
    //    {
    //        _contact = manager.Contact;
    //    }
    //    public ContactsController()
    //    { 

    //    }
    //    // GET: api/Contact
    //    public IEnumerable<ContactViewModel> GetContacts()
    //    {
    //        var query = _contact.GetAllContact();
    //        return query.Select(s => new ContactViewModel(s));
    //    }

    //    // GET: api/Contact/5
    //    [Route("api/Contact/{id?}")]
    //    public HttpResponseMessage Get(int id)
    //    {
    //        try
    //        {
    //            var contact = _contact.GetContactByID(id);
    //            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contact);
    //            return response;
    //        }
    //        catch (Exception ex)
    //        {
    //            var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
    //            responseMessage.Content = new StringContent(ex.Message);
    //            throw new HttpResponseException(responseMessage);
    //        }

    //    }

    //    // POST: api/Contact
    //    //[Route("api/Contact")]
    //    public HttpResponseMessage Post([FromBody] ContactViewModel model)
    //    {
    //        try
    //        {
    //            var contact = _contact.CreateContactAsync(model);
    //            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contact);
    //            return response;
    //        }
    //        catch (Exception ex)
    //        {
    //            var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
    //            responseMessage.Content = new StringContent(ex.Message);
    //            throw new HttpResponseException(responseMessage);
    //        }
    //    }

    //    // PUT: api/Contact/5
    //    //[Route("api/Contact/{id?")]
    //    public HttpResponseMessage Put(int id, [FromBody] ContactViewModel model)
    //    {
    //        try
    //        {
    //            var contact = _contact.EditContactAsync(model);
    //            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contact);
    //            return response;
    //        }
    //        catch (Exception ex)
    //        {
    //            var responseMessage = new HttpResponseMessage(HttpStatusCode.NotModified);
    //            responseMessage.Content = new StringContent(ex.Message);
    //            throw new HttpResponseException(responseMessage);
    //        }
    //    }

    //    // DELETE: api/Contact/5
    //    //[Route("api/Contact/{id?")]
    //    public async Task<HttpResponseMessage> Delete(int id)
    //    {
    //        try
    //        {
                
    //            var contact = await _contact.DeleteContact(id);
    //            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contact);
    //            return response;
    //        }
    //        catch (Exception ex)
    //        {
    //            var responseMessage = new HttpResponseMessage(HttpStatusCode.NotImplemented);
    //            responseMessage.Content = new StringContent(ex.Message);
    //            throw new HttpResponseException(responseMessage);
    //        }

      //}
    }
}
