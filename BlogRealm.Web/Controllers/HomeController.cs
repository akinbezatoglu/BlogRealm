using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using BlogRealm.Web.DTO;
using PagedList;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogRealm.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public HomeController() { }
        public HomeController(IBlogService blogService, IMapper mapper)
        {
            this._blogService = blogService;
            this._mapper = mapper;
        }

        public async Task<ActionResult> Index(int? page)
        {
            int pageNumber = (page ?? 1);
            IEnumerable<Blog> blogs = await _blogService.GetAllWithAuthorAndCategory();
            IEnumerable<BlogSmallDTO> blogsResources = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogSmallDTO>>(blogs);
            
            IPagedList<BlogSmallDTO> pagedBlogs = blogsResources.ToPagedList<BlogSmallDTO>(pageNumber, 9);

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Blog/BlogList.cshtml", pagedBlogs);
            }

            return View(pagedBlogs);
        }
    }
}