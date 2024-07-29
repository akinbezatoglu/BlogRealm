using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class SocialMediaAccountService : ISocialMediaAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SocialMediaAccountService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<SocialMediaAccount> CreateSocialMediaAccount(SocialMediaAccount newSocialMediaAccount)
        {
            _unitOfWork.SocialMediaAccounts.Add(newSocialMediaAccount);
            await _unitOfWork.CommitAsync();

            return newSocialMediaAccount;
        }

        public async Task DeleteSocialMediaAccount(SocialMediaAccount socialMediaAccount)
        {
            _unitOfWork.SocialMediaAccounts.Remove(socialMediaAccount);
            await _unitOfWork.CommitAsync();
        }

        public async Task<SocialMediaAccount> GetById(int id)
        {
            return await _unitOfWork.SocialMediaAccounts.GetByIdAsync(id);
        }
    }
}
