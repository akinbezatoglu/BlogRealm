using BlogRealm.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface IUserService
    {
        Task<User> GetById(int id);
        Task<User> GetWithRoleById(int id);
        Task<IEnumerable<User>> GetAllWithRole();
        Task<User> CreateUser(User newUser);
        Task UpdateUser(User userToBeUpdated, User user);
        Task DeleteUser(User user);
    }
}
