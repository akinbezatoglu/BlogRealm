using BlogRealm.Core.Models;
using BlogRealm.Core.Repositories;
using BlogRealm.Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BlogRealm.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BlogRealmDbContext context)
            : base(context)
        { }

        private BlogRealmDbContext BlogRealmDbContext
        {
            get { return Context as BlogRealmDbContext; }
        }

        public async Task<IEnumerable<User>> GetAllWithRoleAsync()
        {
            return await BlogRealmDbContext.Users
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<User> GetWithRoleByIdAsync(int id)
        {
            return await BlogRealmDbContext.Users
                .Include(u => u.Role)
                .SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
