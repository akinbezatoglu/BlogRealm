using BlogRealm.Core.Models;
using BlogRealm.Core.Repositories;
using BlogRealm.Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BlogRealm.Data.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogRealmDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Blog>> GetAllByAuthorIdAsync(int authorId)
        {
            return await BlogRealmDbContext.Blogs
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await BlogRealmDbContext.Blogs
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllWithAuthorAndCategoryAsync()
        {
            return await BlogRealmDbContext.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllWithAuthorByCategoryIdAsync(int categoryId)
        {
            return await BlogRealmDbContext.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllWithCategoryAsync()
        {
            return await BlogRealmDbContext.Blogs
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllWithCategoryByAuthorIdAsync(int authorId)
        {
            return await BlogRealmDbContext.Blogs
                .Include(b => b.Category)
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<Blog> GetWithAuthorAndCategoryAndCommentsByIdAsync(int id)
        {
            return await BlogRealmDbContext.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Comments)
                .SingleOrDefaultAsync(b => b.Id == id);
        }

        public IEnumerable<IGrouping<int, Blog>> GroupByCategoryId(IEnumerable<Blog> blogs)
        {
            return blogs.GroupBy(b => b.CategoryId);
        }

        public IEnumerable<IGrouping<int, Blog>> GroupByAuthorId(IEnumerable<Blog> blogs)
        {
            return blogs.GroupBy(b => b.AuthorId);
        }

        public IEnumerable<Blog> OrderByDescendingByDate(IEnumerable<Blog> blogs)
        {
            return blogs.OrderByDescending(b => b.Date);
        }

        public IEnumerable<Blog> SelectFirstDescending(IEnumerable<IGrouping<int, Blog>> groupedBlogs)
        {
            return groupedBlogs.Select(s => s.OrderByDescending(b => b.Date).FirstOrDefault()).ToList();
        }

        private BlogRealmDbContext BlogRealmDbContext
        {
            get { return Context as BlogRealmDbContext; }
        }
    }
}
