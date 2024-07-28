using BlogRealm.Core.Models;
using BlogRealm.Core.Repositories;
using BlogRealm.Data.Context;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BlogRealm.Data.Repositories
{
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        public AboutRepository(BlogRealmDbContext context)
            : base(context)
        { }

        public async Task<About> GetFirstAsync()
        {
            return await BlogRealmDbContext.Abouts.FirstOrDefaultAsync();
        }

        private BlogRealmDbContext BlogRealmDbContext
        {
            get { return Context as BlogRealmDbContext; }
        }
    }
}
