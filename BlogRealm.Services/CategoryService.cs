using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategory(Category newCateogry)
        {
            _unitOfWork.Categories.Add(newCateogry);
            await _unitOfWork.CommitAsync();

            return newCateogry;
        }

        public async Task DeleteCategory(Category category)
        {
            _unitOfWork.Categories.Remove(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAllWithBlogs()
        {
            return await _unitOfWork.Categories.GetAllWithBlogsAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task<Category> GetByName(string name)
        {
            return await _unitOfWork.Categories.GetByNameAsync(name);
        }

        public async Task<Category> GetWithBlogsById(int id)
        {
            return await _unitOfWork.Categories.GetWithBlogsByIdAsync(id);
        }

        public async Task<Category> GetWithBlogsByName(string name)
        {
            return await _unitOfWork.Categories.GetWithBlogsByNameAsync(name);
        }

        public async Task UpdateCategory(Category categoryToBeUpdated, Category category)
        {
            categoryToBeUpdated.Name = category.Name;
            categoryToBeUpdated.About = category.About;

            await _unitOfWork.CommitAsync();
        }
    }
}
