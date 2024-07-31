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

        // GET: Admin/Contact
        public async Task<ActionResult> Index()
        {
            IEnumerable<Contact> contacts = await _contactService.GetAll();
            IEnumerable<ContactAdminDTO> contactResources = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactAdminDTO>>(contacts);

            return View(contactResources.OrderByDescending(c => c.CreatedDateTime));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                Contact contact = await _contactService.GetById(id);
                await _contactService.DeleteContact(contact);

                return Json(new { success = true, message = $"{contact.Subject}, has been successfully deleted." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e });
            }
        }
    }
}