using System.Web;
using System.Web.Optimization;

namespace BlogRealm.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new Bundle("~/bundles/blogrealmjs").Include(
                      "~/Scripts/tiny-slider.js",
                      "~/Scripts/flatpickr.min.js",
                      "~/Scripts/aos.js",
                      "~/Scripts/glightbox.min.js",
                      "~/Scripts/navbar.js",
                      "~/Scripts/counter.js",
                      "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-grid.css",
                      "~/Content/bootstrap-reboot.css",
                      "~/Content/bootstrap-utilities.css",
                      "~/Content/aos.css",
                      "~/Content/flaticon.css",
                      "~/Content/icomoon.css",
                      "~/Content/tiny-slider.css",
                      "~/Content/glightbox.min.css",
                      "~/Content/flatpickr.min.css",
                      "~/Content/site.css",
                      "~/Content/fonts/flaticon/font/flaticon.css",
                      "~/Content/fonts/flaticon/font/Flaticon.eot",
                      "~/Content/fonts/flaticon/font/Flaticon.ttf",
                      "~/Content/fonts/flaticon/font/Flaticon.woff",
                      "~/Content/fonts/flaticon/font/Flaticon.woff2",
                      "~/Content/fonts/icomoon/icomoon.css",
                      "~/Content/fonts/icomoon/selection.json",
                      "~/Content/fonts/icomoon/fonts/icomoon.eot",
                      "~/Content/fonts/icomoon/fonts/icomoon.ttf",
                      "~/Content/fonts/icomoon/fonts/icomoon.woff"));
        }
    }
}
