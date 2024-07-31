using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogRealm.Web.Areas.Admin.DTO
{
    public class AboutAdminDTO
    {
        public string MainContent { get; set; }
        public string MainContentTitle { get; set; }
        public string MainContentImage { get; set; }

        public string FirstContent { get; set; }
        public string FirstContentTitle { get; set; }
        public string FirstContentImage { get; set; }

        public string SecondContent { get; set; }
        public string SecondContentTitle { get; set; }
        public string SecondContentImage { get; set; }
    }
}