using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Sp16_p3_g__1_
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/_run.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/App").Include(
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/angular.js",
                "~/Scripts/typeahead.js",
                "~/Scripts/ng-infinite-scroll.js",
                "~/Scripts/lub-tmdb.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/mainApp.js",
                "~/lib/qrcode.js",
                "~/Scripts/jqrcode.js",
                "~/Scripts/angular-qr.js",
                "~/Controllers/movieCtrl.js",
                "~/Controllers/adminCtrl.js",
                "~/Service/adminService.js",
                "~/Service/movieService.js",
                "~/Service/scrollService.js",
                "~/Controllers/upcomeCtrl.js",
                "~/Controllers/detailsCtrl.js",
                "~/Controllers/showAddCtrl.js",
                "~/Controllers/cartCtrl.js",
                "~/Controllers/saleCtrl.js"
                ));
        }
    }
}
