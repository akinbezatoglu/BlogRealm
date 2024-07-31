using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogRealm.Web.DTO
{
    public class BlogSmallDTO
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string ContentPreview { get; set; }

        public string Url { get; set; }
        public string CategoryUrl { get; set; }
        public string AuthorUrl { get; set; }

        public AuthorDTO Author { get; set; }
        public CategoryDTO Category { get; set; }
    }
}