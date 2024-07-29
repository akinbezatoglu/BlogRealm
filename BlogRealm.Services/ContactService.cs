using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Contact> CreateContact(Contact newContact)
        {
            _unitOfWork.Contacts.Add(newContact);
            await _unitOfWork.CommitAsync();

            return newContact;
        }

        public async Task DeleteContact(Contact contact)
        {
            _unitOfWork.Contacts.Remove(contact);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Contact> GetById(int id)
        {
            return await _unitOfWork.Contacts.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _unitOfWork.Contacts.GetAllAsync();
        }
    }
}
