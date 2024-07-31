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
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController() { }
        public ContactController(IContactService contactService, IMapper mapper)
        {
            this._contactService = contactService;
            this._mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Index(ContactDTO contactDTO)
        {
            if (ModelState.IsValid)
            {
                contactDTO.CreatedDateTime = DateTime.UtcNow;
                Contact contact = _mapper.Map<ContactDTO, Contact>(contactDTO);
                await _contactService.CreateContact(contact);

                return Json(new { success = true, message = $"Dear {contact.Name}, We received your message. Thank you for reaching out to us." });
            }
            else
            {
                return Json(new { success = false, message = "Your message failed to be delivered." });
            }
        }
    }
}