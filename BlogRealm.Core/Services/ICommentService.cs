using BlogRealm.Core.Models;
using System.Threading.Tasks;

namespace BlogRealm.Core.Services
{
    public interface ICommentService
    {
        Task<Comment> GetById(int id);
        Task<Comment> CreateComment(Comment newComment);
        Task DeleteComment(Comment comment);
    }
}
