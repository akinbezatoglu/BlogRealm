using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BlogRealm.Core.Models
{
    public class Author
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }

        public Author()
        {
            Blogs = new Collection<Blog>();
            SocialMediaAccounts = new Collection<SocialMediaAccount>();
        }
    }
}
