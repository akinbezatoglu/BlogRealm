using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using BlogRealm.Services;
using BlogRealm.Web.Areas.Admin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogRealm.Web.Areas.Admin.Controllers
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

        // GET: Admin/Category
        public async Task<ActionResult> Index()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllWithBlogs();
            IEnumerable<CategoryAdminDTO> categoryResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryAdminDTO>>(categories);

            return View(categoryResources.OrderByDescending(c => c.Blogs.Count));
        }

        public async Task<PartialViewResult> Create()
        {
            return await Task.FromResult(PartialView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(CategoryPostAdminDTO categoryPostDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category category = _mapper.Map<CategoryPostAdminDTO, Category>(categoryPostDTO);
                    await _categoryService.CreateCategory(category);

                    return Json(new { success = true, message = $"{category.Name}, has been successfully created." });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to create category." });
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
                Category category = await _categoryService.GetById(id);
                await _categoryService.DeleteCategory(category);

                return Json(new { success = true, message = $"{category.Name}, has been successfully deleted." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }

        public async Task<PartialViewResult> Update(int id)
        {
            Category category = await _categoryService.GetById(id);
            CategoryUpdateAdminDTO categoryResource = _mapper.Map<Category, CategoryUpdateAdminDTO>(category);
            return await Task.FromResult(PartialView(categoryResource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Update(CategoryUpdateAdminDTO categoryUpdateDTO)
        {
            try
            {
                Category updatedCategory = _mapper.Map<CategoryUpdateAdminDTO, Category>(categoryUpdateDTO);
                Category categoryToBeUpdated = await _categoryService.GetById(categoryUpdateDTO.Id);
                string name = categoryToBeUpdated.Name;
                await _categoryService.UpdateCategory(categoryToBeUpdated, updatedCategory);

                return Json(new { success = true, message = $"{name}, has been successfully updated." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }
    }
}