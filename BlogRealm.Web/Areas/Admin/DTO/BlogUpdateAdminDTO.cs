using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class BlogUpdateAdminDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }

        [AllowHtml]
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public CategorySearchAdminDTO Category { get; set; }
        public AuthorSearchAdminDTO Author { get; set; }

    }
}