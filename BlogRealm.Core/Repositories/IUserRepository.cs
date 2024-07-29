using BlogRealm.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetWithRoleByIdAsync(int id);
        Task<IEnumerable<User>> GetAllWithRoleAsync();
    }
}
