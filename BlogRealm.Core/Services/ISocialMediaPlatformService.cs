using BlogRealm.Core.Models;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface ISocialMediaPlatformService
    {
        Task<SocialMediaPlatform> GetById(int id);
        Task<SocialMediaPlatform> CreateSocialMediaPlatform(SocialMediaPlatform newSocialMediaPlatform);
        Task DeleteSocialMediaPlatform(SocialMediaPlatform socialMediaPlatform);
    }
}
