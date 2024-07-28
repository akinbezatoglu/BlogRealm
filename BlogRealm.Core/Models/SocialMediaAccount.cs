namespace BlogRealm.Core.Models
{
    public class SocialMediaAccount
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int PlatformId { get; set; }
        public string Username { get; set; }
        public virtual Author Author { get; set; }
        public virtual SocialMediaPlatform SocialMediaPlatform { get; set; }
    }
}
