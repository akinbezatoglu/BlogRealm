using BlogRealm.Core.Models;
using System;
using System.Collections.Generic;

namespace BlogRealm.Web.DTO
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public string Url { get; set; }
        public string CategoryUrl { get; set; }
        public string AuthorUrl { get; set; }

        public AuthorDTO Author { get; set; }
        public CategoryDTO Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}