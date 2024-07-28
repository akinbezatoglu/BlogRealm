using BlogRealm.Core.Models;
using System.Threading.Tasks;

namespace BlogRealm.Core.Repositories
{
    public interface IAboutRepository : IRepository<About>
    {
        Task<About> GetFirstAsync();
    }
}
