using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BlogRealm.Core.Models
{
    public class SocialMediaPlatform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DefaultUrl { get; set; }
        public virtual ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }

        public SocialMediaPlatform()
        {
            SocialMediaAccounts = new Collection<SocialMediaAccount>();
        }
    }
}
