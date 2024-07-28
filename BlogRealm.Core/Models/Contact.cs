using System;

namespace BlogRealm.Core.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Contact()
        {
            this.CreatedDateTime = DateTime.UtcNow;
        }
    }
}
