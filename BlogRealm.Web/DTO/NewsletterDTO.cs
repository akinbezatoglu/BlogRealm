using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogRealm.Web.DTO
{
    public class NewsletterDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}