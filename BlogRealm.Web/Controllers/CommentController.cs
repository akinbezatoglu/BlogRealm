using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using BlogRealm.Web.DTO;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogRealm.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController() { }
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            this._commentService = commentService;
            this._mapper = mapper;
        }

        public Task<PartialViewResult> Reply(int id)
        {
            return Task.FromResult(PartialView(new CommentDTO { BlogId = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Reply(CommentDTO commentDTO)
        {
            if (ModelState.IsValid)
            {
                commentDTO.CreatedDateTime = DateTime.UtcNow;
                Comment comment = _mapper.Map<CommentDTO, Comment>(commentDTO);
                await _commentService.CreateComment(comment);
                return Json(new { success = true, message = $"{comment.Username}, Thanks for your comment." });
            }
            else
            {
                return Json(new { success = false, message = "Your comment failed to be delivered." });
            }
        }
    }
}