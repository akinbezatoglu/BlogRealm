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
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutController() { }
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            this._aboutService = aboutService;
            this._mapper = mapper;
        }

        // GET: Admin/About
        public async Task<ActionResult> Index()
        {
            About about = await _aboutService.GetAbout();
            AboutAdminDTO aboutResource = _mapper.Map<About, AboutAdminDTO>(about);

            return View(aboutResource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Index(AboutAdminDTO aboutDTO)
        {
            try
            {
                About updatedAbout = _mapper.Map<AboutAdminDTO, About>(aboutDTO);
                About aboutToBeUpdated = await _aboutService.GetAbout();
                await _aboutService.UpdateAbout(aboutToBeUpdated, updatedAbout);

                return Json(new { success = true, message = "About, has been successfully updated." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }
    }
}