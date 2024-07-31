using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using BlogRealm.Services;
using BlogRealm.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogRealm.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController() { }
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        // GET: Category/{id}
        public async Task<ActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("All", "Category");
            }

            Category category = await _categoryService.GetWithBlogsById(id.Value);
            CategoryDTO categoryResource = _mapper.Map<Category, CategoryDTO>(category);

            return View(categoryResource);
        }

        public async Task<ActionResult> All()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllWithBlogs();
            categories = categories.OrderByDescending(c => c.Blogs.Count).ToList();
            IEnumerable<CategoryDTO> categoriesResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return View(categoriesResources);
        }

        public async Task<PartialViewResult> Navbar()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllWithBlogs();
            categories = categories.OrderByDescending(c => c.Blogs.Count).ToList();
            IEnumerable<CategoryDTO> categoriesResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);

            if (categories.Count() > 7)
            {
                return PartialView(categoriesResources.Take(7));
            }
            
            return PartialView(categoriesResources);
        }
    }
}