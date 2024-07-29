using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class NewsletterService : INewsletterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NewsletterService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Newsletter> AddtoNewsletter(Newsletter newsletter)
        {
            _unitOfWork.Newsletters.Add(newsletter);
            await _unitOfWork.CommitAsync();

            return newsletter;
        }

        public async Task<Newsletter> GetById(int id)
        {
            return await _unitOfWork.Newsletters.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Newsletter>> GetAll()
        {
            return await _unitOfWork.Newsletters.GetAllAsync();
        }

        public async Task DeleteSubscriber(Newsletter newsletter)
        {
            _unitOfWork.Newsletters.Remove(newsletter);
            await _unitOfWork.CommitAsync();
        }
    }
}
