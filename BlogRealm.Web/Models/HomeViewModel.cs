using BlogRealm.Web.DTO;
using System.Collections.Generic;

namespace BlogRealm.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<HomeViewBlogDTO> recentBlogsByAuthor { get; set; }
        public IEnumerable<HomeViewBlogDTO> recentBlogsOfCategoryFirst { get; set; }
        public IEnumerable<HomeViewBlogDTO> recentBlogs { get; set; }
        public IEnumerable<HomeViewBlogDTO> recentBlogsOfCategorySecond { get; set; }
        public IEnumerable<HomeViewBlogDTO> recentBlogsOfCategoryThird { get; set; }
        public IEnumerable<HomeViewBlogDTO> recentBlogsOfCategoryFourth { get; set; }
    }
}
