using BlogRealm.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface ICategoryService
    {
        Task<Category> GetById(int id);
        Task<Category> GetWithBlogsById(int id);
        Task<Category> GetByName(string name);
        Task<Category> GetWithBlogsByName(string name);
        Task<IEnumerable<Category>> GetAllWithBlogs();
        Task<IEnumerable<Category>> GetAll();

        Task<Category> CreateCategory(Category newCateogry);
        Task UpdateCategory(Category categoryToBeUpdated, Category category);
        Task DeleteCategory(Category category);
    }
}
