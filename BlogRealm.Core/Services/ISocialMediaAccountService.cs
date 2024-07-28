using BlogRealm.Core.Models;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface ISocialMediaAccountService
    {
        Task<SocialMediaAccount> GetById(int id);
        Task<SocialMediaAccount> CreateSocialMediaAccount(SocialMediaAccount newSocialMediaAccount);
        Task DeleteSocialMediaAccount(SocialMediaAccount socialMediaAccount);
    }
}
