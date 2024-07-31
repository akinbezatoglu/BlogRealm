using BlogRealm.Web.DTO;
using System.Collections.Generic;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class AuthorAdminDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string EditUrl { get; set; }
        public string DeleteUrl { get; set; }
        public string Fullname { get; set; }
        public string Image { get; set; }
        public string About { get; set; }

        public ICollection<BlogSmallDTO> Blogs { get; set; }
    }
}