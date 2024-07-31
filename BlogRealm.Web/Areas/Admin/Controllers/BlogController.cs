using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using BlogRealm.Web.Areas.Admin.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogRealm.Web.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public BlogController() { }
        public BlogController(IBlogService blogService, IAuthorService authorService, ICategoryService categoryService, IMapper mapper)
        {
            this._blogService = blogService;
            this._authorService = authorService;
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        // GET: Admin/Blog
        public async Task<ActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _blogService.GetAllWithAuthorAndCategory();
            IEnumerable<BlogSmallAdminDTO> blogsResources = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogSmallAdminDTO>>(blogs);

            IEnumerable<Author> authors = await _authorService.GetAllWithBlogs();
            IEnumerable<AuthorSearchAdminDTO> authorResources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorSearchAdminDTO>>(authors);
            ViewBag.Authors = authorResources;

            IEnumerable<Category> categories = await _categoryService.GetAllWithBlogs();
            IEnumerable<CategorySearchAdminDTO> categoryResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategorySearchAdminDTO>>(categories);
            ViewBag.Categories = categoryResources;

            return View(blogsResources.OrderByDescending(b => b.Date));
        }

        public async Task<PartialViewResult> Create()
        {
            return await Task.FromResult(PartialView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(BlogPostAdminDTO blogPostDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Blog blog = _mapper.Map<BlogPostAdminDTO, Blog>(blogPostDTO);
                    await _blogService.CreateBlog(blog);

                    return Json(new { success = true, message = $"{blog.Title}, has been successfully created." });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to create blog." });
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                Blog blog = await _blogService.GetById(id);
                await _blogService.DeleteBlog(blog);

                return Json(new { success = true, message = $"{blog.Title}, has been successfully deleted." });
            }              
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }

        public async Task<PartialViewResult> Update(int id)
        {
            Blog blog = await _blogService.GetById(id);
            BlogUpdateAdminDTO blogResource = _mapper.Map<Blog, BlogUpdateAdminDTO>(blog);
            return await Task.FromResult(PartialView(blogResource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Update(BlogUpdateAdminDTO blogUpdateDTO)
        {
            try
            {
                Blog updatedBlog = _mapper.Map<BlogUpdateAdminDTO, Blog>(blogUpdateDTO);
                Blog blogToBeUpdated = await _blogService.GetById(blogUpdateDTO.Id);
                string title = blogToBeUpdated.Title;
                await _blogService.UpdateBlog(blogToBeUpdated, updatedBlog);

                return Json(new { success = true, message = $"{title}, has been successfully updated." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }
    }
}