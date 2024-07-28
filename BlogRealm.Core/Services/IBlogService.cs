using BlogRealm.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface IBlogService
    {
        Task<Blog> GetById(int id);
        Task<Blog> GetWithAuthorAndCategoryAndCommentsById(int id);

        Task<IEnumerable<Blog>> GetAllWithCategory();
        Task<IEnumerable<Blog>> GetAllWithAuthorAndCategory();

        Task<IEnumerable<Blog>> GetAllByAuthorId(int authorId);
        Task<IEnumerable<Blog>> GetAllWithCategoryByAuthorId(int authorId);

        Task<IEnumerable<Blog>> GetAllByCategoryId(int categoryId);
        Task<IEnumerable<Blog>> GetAllWithAuthorByCategoryId(int categoryId);

        Task<IEnumerable<Blog>> GetRecentBlogsWithCategory();
        Task<IEnumerable<Blog>> GetRecentBlogsWithAuthorAndCategory();
        Task<IEnumerable<Blog>> GetRecentBlogOfEachCategoryWithCategory();
        Task<IEnumerable<Blog>> GetRecentBlogOfEachCategoryWithAuthorAndCategory();

        Task<Blog> CreateBlog(Blog newBlog);
        Task UpdateBlog(Blog blogToBeUpdated, Blog blog);
        Task DeleteBlog(Blog blog);
    }
}
