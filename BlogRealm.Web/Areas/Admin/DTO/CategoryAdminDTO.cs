using BlogRealm.Web.DTO;
using System.Collections.Generic;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class CategoryAdminDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Url { get; set; }
        public string EditUrl { get; set; }
        public string DeleteUrl { get; set; }

        public ICollection<BlogSmallDTO> Blogs { get; set; }
    }
}