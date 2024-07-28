using BlogRealm.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogRealm.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> GetWithBlogsByIdAsync(int id);
        Task<IEnumerable<Author>> GetAllWithBlogsAsync();
        IEnumerable<Author> OrderByDescendingByBlogsCount(IEnumerable<Author> authors);
    }
}
