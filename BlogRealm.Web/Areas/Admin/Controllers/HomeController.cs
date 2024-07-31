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
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public HomeController() { }
        public HomeController(ICategoryService categoryService, IAuthorService authorService, IMapper mapper)
        {
            this._authorService = authorService;
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> CategoryChart()
        {
            try
            {
                IEnumerable<Category> categories = await _categoryService.GetAllWithBlogs();
                IEnumerable<CategoryChartAdminDTO> categoryResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryChartAdminDTO>>(categories);

                return Json(categoryResources, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> AuthorChart()
        {
            try
            {
                IEnumerable<Author> authors = await _authorService.GetAllWithBlogs();
                IEnumerable<AuthorChartAdminDTO> authorResources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorChartAdminDTO>>(authors);

                return Json(authorResources, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}