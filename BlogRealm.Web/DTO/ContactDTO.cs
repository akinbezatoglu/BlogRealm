using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogRealm.Web.DTO
{
    public class ContactDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public ContactDTO()
        {
            this.CreatedDateTime = DateTime.UtcNow;
        }
    }
}