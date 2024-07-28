using BlogRealm.Core.Models;
using BlogRealm.Core.Repositories;
using BlogRealm.Data.Context;

namespace BlogRealm.Data.Repositories
{
    public class SocialMediaPlatformRepository : Repository<SocialMediaPlatform>, ISocialMediaPlatformRepository
    {
        public SocialMediaPlatformRepository(BlogRealmDbContext context)
            : base(context)
        { }

        private BlogRealmDbContext BlogRealmDbContext
        {
            get { return Context as BlogRealmDbContext; }
        }
    }
}
