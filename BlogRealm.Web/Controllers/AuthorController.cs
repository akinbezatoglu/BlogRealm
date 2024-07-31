using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using BlogRealm.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogRealm.Web.Controllers
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

        // GET: Author
        public async Task<ActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("All", "Author");
            }

            Author authorWithBlogs = await _authorService.GetWithBlogsById(id.Value);
            AuthorDTO authorWithBlogsResources = _mapper.Map<AuthorDTO>(authorWithBlogs);

            return View(authorWithBlogsResources);
        }

        public async Task<ActionResult> All()
        {
            IEnumerable<Author> authors = await _authorService.GetAllWithBlogs();
            IEnumerable<AuthorDTO> authorsResources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(authors);
            
            return View(authorsResources);
        }

        public async Task<PartialViewResult> FeaturedAuthors()
        {
            IEnumerable<Author> authors = await _authorService.GetAllWithBlogsOrderByDescendingByBlogsCount();

            if (authors.Count() < 3)
            {
                return PartialView(Enumerable.Empty<AuthorDTO>());
            }

            IEnumerable<AuthorDTO> authorsResources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(authors.Take(3));
            return PartialView(authorsResources);
        }
    }
}