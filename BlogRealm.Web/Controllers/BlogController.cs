using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using BlogRealm.Web.DTO;
using PagedList;
using PagedList.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace BlogRealm.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController() { }
        public BlogController(IBlogService blogService, IMapper mapper)
        {
            this._blogService = blogService;
            this._mapper = mapper;
        }

        // GET: Blog/{id}
        public async Task<ActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("All", "Blog");
            }

            Blog blog = await _blogService.GetWithAuthorAndCategoryAndCommentsById(id.Value);
            blog.Comments = blog.Comments.OrderBy(c => c.CreatedDateTime).ToList();

            BlogDTO blogResource = _mapper.Map<Blog, BlogDTO>(blog);
            
            return View(blogResource);
        }

        public async Task<ActionResult> All(int? page)
        {
            int pageNumber = (page ?? 1);
            IEnumerable<Blog> blogs = await _blogService.GetAllWithAuthorAndCategory();
            IEnumerable<BlogSmallDTO> blogsResources = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogSmallDTO>>(blogs);
            return View(blogsResources.ToPagedList(pageNumber, 15));
        }

        public async Task<PartialViewResult> RecentBlogs()
        {
            IEnumerable<Blog> recentBlogs = await _blogService.GetRecentBlogsWithAuthorAndCategory();

            if (recentBlogs.Count() < 5)
            {
                return PartialView(Enumerable.Empty<BlogSmallDTO>());
            }

            IEnumerable<BlogSmallDTO> recentBlogsResources = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogSmallDTO>>(recentBlogs);

            return PartialView(recentBlogsResources.Take(5));
        }

        public async Task<PartialViewResult> BlogList(int? page)
        {
            int pageNumber = (page ?? 1);
            IEnumerable<Blog> blogs = await _blogService.GetAllWithAuthorAndCategory();
            IEnumerable<BlogSmallDTO> blogsResources = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogSmallDTO>>(blogs);
            
            return PartialView(blogsResources.ToPagedList(pageNumber, 9));
        }

        public async Task<PartialViewResult> RecentBlogsByCategory()
        {
            IEnumerable<Blog> recentBlogsByCategory = await _blogService.GetRecentBlogOfEachCategoryWithAuthorAndCategory();

            if (recentBlogsByCategory.Count() < 4)
            {
                return PartialView(Enumerable.Empty<BlogSmallDTO>());
            }

            IEnumerable<BlogSmallDTO> recentBlogsByCategoryResources = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogSmallDTO>>(recentBlogsByCategory);
            return PartialView(recentBlogsByCategoryResources.Take(4));
        }
    }
}