using BlogRealm.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogRealm.Core.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<Blog> GetWithAuthorAndCategoryAndCommentsByIdAsync(int id);

        Task<IEnumerable<Blog>> GetAllWithCategoryAsync();
        Task<IEnumerable<Blog>> GetAllWithAuthorAndCategoryAsync();

        Task<IEnumerable<Blog>> GetAllByAuthorIdAsync(int authorId);
        Task<IEnumerable<Blog>> GetAllWithCategoryByAuthorIdAsync(int authorId);

        Task<IEnumerable<Blog>> GetAllByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Blog>> GetAllWithAuthorByCategoryIdAsync(int categoryId);

        IEnumerable<IGrouping<int, Blog>> GroupByCategoryId(IEnumerable<Blog> blogs);
        IEnumerable<Blog> SelectFirstDescending(IEnumerable<IGrouping<int, Blog>> groupedBlogs);
        IEnumerable<Blog> OrderByDescendingByDate(IEnumerable<Blog> blogs);
    }
}
