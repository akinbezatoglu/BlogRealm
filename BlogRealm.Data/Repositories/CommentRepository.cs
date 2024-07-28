using BlogRealm.Core.Models;
using BlogRealm.Core.Repositories;
using BlogRealm.Data.Context;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogRealmDbContext context)
            : base(context)
        { }

        private BlogRealmDbContext BlogRealmDbContext
        {
            get { return Context as BlogRealmDbContext; }
        }
    }
}
