using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class AuthorChartAdminDTO
    {
        public string Fullname { get; set; }
        public string Url { get; set; }
        public int BlogsCount { get; set; }
    }
}