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

        // GET: About
        public async Task<ActionResult> Index()
        {
            About about = await _aboutService.GetAbout();
            AboutDTO aboutResource = _mapper.Map<About, AboutDTO>(about);
            return View(aboutResource);
        }

        public async Task<PartialViewResult> Footer()
        {
            About about =  await _aboutService.GetAbout();
            AboutFooterDTO aboutResource =  _mapper.Map<About, AboutFooterDTO>(about);
            return PartialView(aboutResource);
        }
    }
}