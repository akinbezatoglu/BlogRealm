using BlogRealm.Core.Models;
using BlogRealm.Core.Repositories;
using BlogRealm.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogRealm.Data.Repositories
{
    public class NewsletterRepository : Repository<Newsletter>, INewsletterRepository
    {
        public NewsletterRepository(BlogRealmDbContext context)
            : base(context)
        { }

        private BlogRealmDbContext BlogRealmDbContext
        {
            get { return Context as BlogRealmDbContext; }
        }
    }
}
