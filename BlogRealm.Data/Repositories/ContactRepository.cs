using BlogRealm.Core.Models;
using BlogRealm.Core.Repositories;
using BlogRealm.Data.Context;

namespace BlogRealm.Data.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(BlogRealmDbContext context)
            : base(context)
        { }

        private BlogRealmDbContext BlogRealmDbContext
        {
            get { return Context as BlogRealmDbContext; }
        }
    }
}
