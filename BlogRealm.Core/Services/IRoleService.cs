using BlogRealm.Core.Models;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface IRoleService
    {
        Task<Role> GetById(int id);
        Task<Role> CreateRole(Role newRole);
        Task DeleteRole(Role role);
    }
}
