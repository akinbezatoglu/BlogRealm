using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUser(User newUser)
        {
            _unitOfWork.Users.Add(newUser);
            await _unitOfWork.CommitAsync();

            return newUser;
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<User>> GetAllWithRole()
        {
            return await _unitOfWork.Users.GetAllWithRoleAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<User> GetWithRoleById(int id)
        {
            return await _unitOfWork.Users.GetWithRoleByIdAsync(id);
        }

        public async Task UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.Username = user.Username;
            userToBeUpdated.Password = user.Password;
            userToBeUpdated.RoleId = user.RoleId;

            await _unitOfWork.CommitAsync();
        }
    }
}
