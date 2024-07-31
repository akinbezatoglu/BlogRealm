using System.Collections.Generic;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class BlogCommentsAdminDTO
    {
        public string Title { get; set; }
        public ICollection<CommentAdminDTO> Comments { get; set; }
    }
}