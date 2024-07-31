using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using BlogRealm.Web.DTO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogRealm.Web.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;
        private readonly IMapper _mapper;
        public NewsletterController() { }
        public NewsletterController(INewsletterService newsletterService, IMapper mapper)
        {
            this._newsletterService = newsletterService;
            this._mapper = mapper;
        }

        public Task<PartialViewResult> Index()
        {
            return Task.FromResult(PartialView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Index(NewsletterDTO newsletterDTO)
        {
            if (ModelState.IsValid)
            {
                Newsletter newsletter = _mapper.Map<NewsletterDTO, Newsletter>(newsletterDTO);
                await _newsletterService.AddtoNewsletter(newsletter);
                
                return Json(new { success = true, message = "Thank you for subscribing!" });
            }
            else
            {
                return Json(new { success = false, message = "Please enter a valid email address." });
            }
        }
    }
}