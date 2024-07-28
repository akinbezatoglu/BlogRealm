using BlogRealm.Core.Models;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface IAboutService
    {
        Task<About> GetAbout();
        Task UpdateAbout(About aboutToBeUpdated, About about);
    }
}
