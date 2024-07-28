using BlogRealm.Core.Models;
using BlogRealm.Core.Repositories;
using BlogRealm.Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BlogRealm.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogRealmDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Category>> GetAllWithBlogsAsync()
        {
            return await BlogRealmDbContext.Categories
                .Include(c => c.Blogs)
                .ToListAsync();
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await BlogRealmDbContext.Categories
                .SingleOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Category> GetWithBlogsByIdAsync(int id)
        {
            return await BlogRealmDbContext.Categories
                .Include(c => c.Blogs)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> GetWithBlogsByNameAsync(string name)
        {
            return await BlogRealmDbContext.Categories
                .Include(c => c.Blogs)
                .SingleOrDefaultAsync(c => c.Name == name);
        }

        private BlogRealmDbContext BlogRealmDbContext
        {
            get { return Context as BlogRealmDbContext; }
        }
    }
}
