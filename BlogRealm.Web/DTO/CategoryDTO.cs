using BlogRealm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogRealm.Web.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string Url { get; set; }
        public ICollection<BlogSmallDTO> Blogs { get; set; }
    }
}