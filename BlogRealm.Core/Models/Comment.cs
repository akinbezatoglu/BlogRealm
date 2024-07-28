using System;

namespace BlogRealm.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public virtual Blog Blog { get; set; }

        public Comment()
        {
            this.CreatedDateTime = DateTime.UtcNow;
        }
    }
}
