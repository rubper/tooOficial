using System.Web.Optimization;

namespace Too
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.min.js",
                        "~/Scripts/active.js",
                        "~/Scripts/classy-nav.min.js",
                        "~/Scripts/map-active.js",
                        "~/Scripts/plugins.js",
                        "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/boostrap.min.css",
                      "~/Content/style.css",
                      "~/Content/animate.css",
                      "~/Content/classy-nav.min.css",
                      "~/Content/core-style.css",
                      "~/Content/core-style.css.map",
                      "~/Content/jquery-ui.min.css",
                      "~/Content/nice-select.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/style.scss",
                      "~/Content/magnific-popup.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/_mixin.scss",
                      "~/Content/_resposive.scss",
                      "~/Content/_theme_color.scss",
                      "~/Content/_variables.scss"
                      ));
        }
    }
}
