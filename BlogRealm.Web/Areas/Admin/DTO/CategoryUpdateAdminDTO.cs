using BlogRealm.Web.DTO;
using System.Collections.Generic;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class CategoryUpdateAdminDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
    }
}