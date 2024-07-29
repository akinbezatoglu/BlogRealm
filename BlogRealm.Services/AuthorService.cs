using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Author> CreateAuthor(Author newAuthor)
        {
            _unitOfWork.Authors.Add(newAuthor);
            await _unitOfWork.CommitAsync();

            return newAuthor;
        }

        public async Task DeleteAuthor(Author author)
        {
            _unitOfWork.Authors.Remove(author);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Author>> GetAllWithBlogs()
        {
            return await _unitOfWork.Authors.GetAllWithBlogsAsync();
        }

        public async Task<IEnumerable<Author>> GetAllWithBlogsOrderByDescendingByBlogsCount()
        {
            IEnumerable<Author> authors = await _unitOfWork.Authors.GetAllWithBlogsAsync();
            return _unitOfWork.Authors.OrderByDescendingByBlogsCount(authors);
        }

        public async Task<Author> GetById(int id)
        {
            return await _unitOfWork.Authors.GetByIdAsync(id);
        }

        public async Task<Author> GetWithBlogsById(int id)
        {
            return await _unitOfWork.Authors.GetWithBlogsByIdAsync(id);
        }

        public async Task UpdateAuthor(Author authorToBeUpdated, Author author)
        {
            authorToBeUpdated.Fullname = author.Fullname;
            authorToBeUpdated.Image = author.Image;
            authorToBeUpdated.About = author.About;

            await _unitOfWork.CommitAsync();
        }
    }
}
