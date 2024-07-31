using BlogRealm.Core.Models;
using System.Collections.Generic;

namespace BlogRealm.Web.DTO
{
    public class AuthorDTO
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }

        public virtual ICollection<BlogSmallDTO> Blogs { get; set; }
    }
}