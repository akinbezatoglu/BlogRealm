using BlogRealm.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface IAuthorService
    {
        Task<Author> GetById(int id);
        Task<Author> GetWithBlogsById(int id);
        Task<IEnumerable<Author>> GetAllWithBlogs();
        Task<IEnumerable<Author>> GetAllWithBlogsOrderByDescendingByBlogsCount();
        Task<Author> CreateAuthor(Author newAuthor);
        Task UpdateAuthor(Author authorToBeUpdated, Author author);
        Task DeleteAuthor(Author author);
    }
}
