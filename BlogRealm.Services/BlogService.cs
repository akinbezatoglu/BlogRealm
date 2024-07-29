using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Blog> CreateBlog(Blog newBlog)
        {
            _unitOfWork.Blogs.Add(newBlog);
            await _unitOfWork.CommitAsync();

            return newBlog;
        }

        public async Task DeleteBlog(Blog blog)
        {
            _unitOfWork.Blogs.Remove(blog);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllByAuthorId(int authorId)
        {
            return await _unitOfWork.Blogs.GetAllByAuthorIdAsync(authorId);
        }

        public async Task<IEnumerable<Blog>> GetAllByCategoryId(int categoryId)
        {
            return await _unitOfWork.Blogs.GetAllByCategoryIdAsync(categoryId);
        }

        public async Task<IEnumerable<Blog>> GetAllWithAuthorAndCategory()
        {
            return await _unitOfWork.Blogs.GetAllWithAuthorAndCategoryAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllWithAuthorByCategoryId(int categoryId)
        {
            return await _unitOfWork.Blogs.GetAllWithAuthorByCategoryIdAsync(categoryId);
        }

        public async Task<IEnumerable<Blog>> GetAllWithCategory()
        {
            return await _unitOfWork.Blogs.GetAllWithCategoryAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllWithCategoryByAuthorId(int authorId)
        {
            return await _unitOfWork.Blogs.GetAllWithCategoryByAuthorIdAsync(authorId);
        }

        public async Task<Blog> GetById(int id)
        {
            return await _unitOfWork.Blogs.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetRecentBlogOfEachCategoryWithAuthorAndCategory()
        {
            var blogs = await _unitOfWork.Blogs.GetAllWithAuthorAndCategoryAsync();
            var groupedBlogsByCategory = _unitOfWork.Blogs.GroupByCategoryId(blogs);
            var firstRecentBlogOfEachCategory = _unitOfWork.Blogs.SelectFirstDescending(groupedBlogsByCategory);

            return _unitOfWork.Blogs.OrderByDescendingByDate(firstRecentBlogOfEachCategory);
        }

        public async Task<IEnumerable<Blog>> GetRecentBlogOfEachCategoryWithCategory()
        {
            var blogs = await _unitOfWork.Blogs.GetAllWithCategoryAsync();
            var groupedBlogsByCategory = _unitOfWork.Blogs.GroupByCategoryId(blogs);
            var firstRecentBlogOfEachCategory = _unitOfWork.Blogs.SelectFirstDescending(groupedBlogsByCategory);
            return _unitOfWork.Blogs.OrderByDescendingByDate(firstRecentBlogOfEachCategory);
        }

        public async Task<IEnumerable<Blog>> GetRecentBlogsWithAuthorAndCategory()
        {
            var blogs = await _unitOfWork.Blogs.GetAllWithAuthorAndCategoryAsync();

            return _unitOfWork.Blogs.OrderByDescendingByDate(blogs);
        }

        public async Task<IEnumerable<Blog>> GetRecentBlogsWithCategory()
        {
            var blogs = await _unitOfWork.Blogs.GetAllWithCategoryAsync();

            return _unitOfWork.Blogs.OrderByDescendingByDate(blogs);
        }

        public async Task<Blog> GetWithAuthorAndCategoryAndCommentsById(int id)
        {
            return await _unitOfWork.Blogs.GetWithAuthorAndCategoryAndCommentsByIdAsync(id);
        }

        public async Task UpdateBlog(Blog blogToBeUpdated, Blog blog)
        {
            blogToBeUpdated.Title = blog.Title;
            blogToBeUpdated.Image = blog.Image;
            blogToBeUpdated.Date = blog.Date;
            blogToBeUpdated.Content = blog.Content;
            blogToBeUpdated.AuthorId = blog.AuthorId;
            blogToBeUpdated.CategoryId = blog.CategoryId;

            await _unitOfWork.CommitAsync();
        }
    }
}
