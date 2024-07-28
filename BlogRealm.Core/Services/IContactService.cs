using BlogRealm.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface IContactService
    {
        Task<Contact> GetById(int id);
        Task<Contact> CreateContact(Contact newContact);
        Task DeleteContact(Contact contact);
        Task<IEnumerable<Contact>> GetAll();
    }
}
