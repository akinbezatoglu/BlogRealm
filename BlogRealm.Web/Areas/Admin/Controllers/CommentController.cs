using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using BlogRealm.Web.Areas.Admin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogRealm.Web.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController() { }
        public CommentController(IBlogService blogService, ICommentService commentService, IMapper mapper)
        {
            this._blogService = blogService;
            this._commentService = commentService;
            this._mapper = mapper;
        }

        // GET: Admin/Comment/Index/{id}
        public async Task<ActionResult> Index(int id)
        {
            Blog blog = await _blogService.GetById(id);
            BlogCommentsAdminDTO comments = _mapper.Map<Blog, BlogCommentsAdminDTO>(blog);
            return View(comments);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                Comment comment = await _commentService.GetById(id);
                await _commentService.DeleteComment(comment);

                return Json(new { success = true, message = $"{comment.Username}'s comment, has been successfully deleted." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }
    }
}