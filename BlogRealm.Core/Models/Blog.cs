using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BlogRealm.Core.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Blog()
        {
            Comments = new Collection<Comment>();
        }
    }
}
