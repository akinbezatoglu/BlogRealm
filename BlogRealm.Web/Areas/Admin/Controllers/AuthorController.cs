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
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController() { }
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            this._authorService = authorService;
            this._mapper = mapper;
        }

        // GET: Admin/Author
        public async Task<ActionResult> Index()
        {
            IEnumerable<Author> authors = await _authorService.GetAllWithBlogs();
            IEnumerable<AuthorAdminDTO> authorResources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorAdminDTO>>(authors);

            return View(authorResources.OrderByDescending(c => c.Blogs.Count));
        }

        public async Task<PartialViewResult> Create()
        {
            return await Task.FromResult(PartialView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(AuthorPostAdminDTO authorPostDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Author author = _mapper.Map<AuthorPostAdminDTO, Author>(authorPostDTO);
                    await _authorService.CreateAuthor(author);

                    return Json(new { success = true, message = $"{author.Name}, has been successfully added." });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to add the author." });
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
                Author author = await _authorService.GetById(id);
                await _authorService.DeleteAuthor(author);

                return Json(new { success = true, message = $"{author.Name}, has been successfully deleted." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }

        public async Task<PartialViewResult> Update(int id)
        {
            Author author = await _authorService.GetById(id);
            AuthorUpdateAdminDTO authorResource = _mapper.Map<Author, AuthorUpdateAdminDTO>(author);
            return await Task.FromResult(PartialView(authorResource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Update(AuthorUpdateAdminDTO authorUpdateDTO)
        {
            try
            {
                Author updatedAuthor = _mapper.Map<AuthorUpdateAdminDTO, Author>(authorUpdateDTO);
                Author authorToBeUpdated = await _authorService.GetById(authorUpdateDTO.Id);
                string name = authorToBeUpdated.Name;
                await _authorService.UpdateAuthor(authorToBeUpdated, updatedAuthor);

                return Json(new { success = true, message = $"{name}, has been successfully updated." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }
    }
}