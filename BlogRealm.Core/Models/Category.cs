using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BlogRealm.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string ColorHexCode { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }

        public Category()
        {
            Blogs = new Collection<Blog>();
        }
    }
}
