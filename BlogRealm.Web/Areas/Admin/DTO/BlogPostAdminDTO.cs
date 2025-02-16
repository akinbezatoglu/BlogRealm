﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class BlogPostAdminDTO
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }

        [AllowHtml]
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}