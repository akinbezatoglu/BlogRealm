using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class SocialMediaPlatformService : ISocialMediaPlatformService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SocialMediaPlatformService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<SocialMediaPlatform> CreateSocialMediaPlatform(SocialMediaPlatform newSocialMediaPlatform)
        {
            _unitOfWork.SocialMediaPlatforms.Add(newSocialMediaPlatform);
            await _unitOfWork.CommitAsync();

            return newSocialMediaPlatform;
        }

        public async Task DeleteSocialMediaPlatform(SocialMediaPlatform socialMediaPlatform)
        {
            _unitOfWork.SocialMediaPlatforms.Remove(socialMediaPlatform);
            await _unitOfWork.CommitAsync();
        }

        public async Task<SocialMediaPlatform> GetById(int id)
        {
            return await _unitOfWork.SocialMediaPlatforms.GetByIdAsync(id);
        }
    }
}
