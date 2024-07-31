using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogRealm.Web.DTO
{
    public class CommentDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int BlogId { get; set; }
    }
}