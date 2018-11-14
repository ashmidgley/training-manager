using System.Web.Optimization;

namespace TrainingManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/star-rating.min.js",
                "~/Content/themes/krajee-fa/theme.js",
                "~/Scripts/Chart.min.js",
                "~/js/app/services/exerciseService.js",
                "~/js/app/services/favouriteService.js",
                "~/js/app/services/planService.js",
                "~/js/app/services/ratingService.js",
                "~/js/app/services/workoutService.js",
                "~/js/app/controllers/favouritesController.js",
                "~/js/app/controllers/indexController.js",
                "~/js/app/controllers/mineController.js",
                "~/js/app/controllers/ratingsController.js",
                "~/js/app/controllers/workoutController.js",
                "~/js/app/app.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/umd/popper.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.js",
                "~/Scripts/bootbox.min.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/star-rating.min.css",
                "~/Content/themes/krajee-fa/theme.css",
                "~/Content/site.css"
            ));
        }
    }
}
