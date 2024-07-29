using BlogRealm.Core;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using System.Threading.Tasks;

namespace BlogRealm.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Comment> CreateComment(Comment newComment)
        {
            _unitOfWork.Comments.Add(newComment);
            await _unitOfWork.CommitAsync();

            return newComment;
        }

        public async Task DeleteComment(Comment comment)
        {
            _unitOfWork.Comments.Remove(comment);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _unitOfWork.Comments.GetByIdAsync(id);
        }
    }
}
