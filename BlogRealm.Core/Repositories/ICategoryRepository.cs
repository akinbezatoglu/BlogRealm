using BlogRealm.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithBlogsByIdAsync(int id);
        Task<Category> GetByNameAsync(string name);
        Task<Category> GetWithBlogsByNameAsync(string name);
        Task<IEnumerable<Category>> GetAllWithBlogsAsync();
    }
}
