using System.Web;
using System.Web.Optimization;

namespace genealogy
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui/css").Include(
                        "~/Content/themes/jquery-ui/jquery.ui.core.css",
                        "~/Content/themes/jquery-ui/jquery.ui.resizable.css",
                        "~/Content/themes/jquery-ui/jquery.ui.selectable.css",
                        "~/Content/themes/jquery-ui/jquery.ui.accordion.css",
                        "~/Content/themes/jquery-ui/jquery.ui.autocomplete.css",
                        "~/Content/themes/jquery-ui/jquery.ui.button.css",
                        "~/Content/themes/jquery-ui/jquery.ui.dialog.css",
                        "~/Content/themes/jquery-ui/jquery.ui.slider.css",
                        "~/Content/themes/jquery-ui/jquery.ui.tabs.css",
                        "~/Content/themes/jquery-ui/jquery.ui.datepicker.css",
                        "~/Content/themes/jquery-ui/jquery.ui.progressbar.css",
                        "~/Content/themes/jquery-ui/jquery.ui.theme.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}