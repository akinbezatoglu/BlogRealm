using System;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class CommentAdminDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}