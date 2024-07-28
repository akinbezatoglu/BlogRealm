using BlogRealm.Core.Models;
using BlogRealm.Core.Repositories;
using BlogRealm.Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BlogRealm.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BlogRealmDbContext context)
            : base(context)
        { }

        public async Task<Author> GetWithBlogsByIdAsync(int id)
        {
            return await BlogRealmDbContext.Authors
                .Include(a => a.Blogs.Select(b => b.Category))
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAllWithBlogsAsync()
        {
            return await BlogRealmDbContext.Authors
                .Include(a => a.Blogs)
                .ToListAsync();
        }

        public IEnumerable<Author> OrderByDescendingByBlogsCount(IEnumerable<Author> authors)
        {
            return authors.OrderByDescending(author => author.Blogs.Count);
        }

        private BlogRealmDbContext BlogRealmDbContext
        {
            get { return Context as BlogRealmDbContext; }
        }
    }
}
