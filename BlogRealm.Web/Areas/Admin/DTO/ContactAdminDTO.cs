using BlogRealm.Web.DTO;
using System;
using System.Collections.Generic;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class ContactAdminDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}