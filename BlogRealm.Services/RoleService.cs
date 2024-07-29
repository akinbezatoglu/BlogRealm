using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Role> CreateRole(Role newRole)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRole(Role role)
        {
            throw new System.NotImplementedException();
        }

        public Task<Role> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
