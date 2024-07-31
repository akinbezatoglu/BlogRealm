using System;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class BlogSmallAdminDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public string Url { get; set; }
        public string EditUrl { get; set; }
        public string DeleteUrl { get; set; }
        public string CommentUrl { get; set; }

        public AuthorAdminDTO Author { get; set; }
        public CategoryAdminDTO Category { get; set; }
    }
}