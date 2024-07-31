using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Core.Services;
using BlogRealm.Services;
using BlogRealm.Web.Areas.Admin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogRealm.Web.Areas.Admin.Controllers
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

        // GET: Admin/Newsletter
        public async Task<ActionResult> Index()
        {
            IEnumerable<Newsletter> newsletters = await _newsletterService.GetAll();
            IEnumerable<NewsletterAdminDTO> newsletterResources = _mapper.Map<IEnumerable<Newsletter>, IEnumerable<NewsletterAdminDTO>>(newsletters);

            return View(newsletterResources);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                Newsletter newsletter = await _newsletterService.GetById(id);
                await _newsletterService.DeleteSubscriber(newsletter);

                return Json(new { success = true, message = $"{newsletter.Email}, has been successfully deleted." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }
    }
}