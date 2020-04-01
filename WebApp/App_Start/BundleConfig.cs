using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            Bundle cssBundle = new Bundle("~/AllCSS");
            cssBundle.Include(
                "~/content/css/open-iconic-bootstrap.min.css",
                "~/content/css/animate.css",
                "~/content/css/owl.carousel.min.css",
                "~/content/css/owl.theme.default.min.css",
                "~/content/css/magnific-popup.css",
                "~/content/css/aos.css",
                "~/content/css/ionicons.min.css",
                "~/content/css/bootstrap-datepicker.css",
                "~/content/css/jquery.timepicker.css",
                "~/content/css/flaticon.css",
                "~/content/css/icomoon.css",
                "~/content/css/style.css",
                "~/content/fonts.css"
                /* https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700,800,900&display=swap */
                );
            bundles.Add(cssBundle);

            //Bundle jsBundle = new Bundle("~/AllJS");
            //jsBundle.Include(
            //    "~/scripts/jquery.min.js",
            //    "~/scripts/jquery-migrate-3.0.1.min.js",
            //    "~/scripts/popper.min.js",
            //    "~/scripts/bootstrap.min.js",
            //    "~/scripts/jquery.easing.1.3.js",
            //    "~/scripts/jquery.waypoints.min.js",
            //    "~/scripts/jquery.stellar.min.js",
            //    "~/scripts/owl.carousel.min.js",
            //    "~/scripts/jquery.magnific-popup.min.js",
            //    "~/scripts/aos.js",
            //    "~/scripts/jquery.animateNumber.min.js",
            //    "~/scripts/bootstrap-datepicker.js",
            //    "~/scripts/jquery.timepicker.min.js",
            //    "~/scripts/scrollax.min.js",
            //    "~/scripts/google-map.js",
            //    "~/scripts/main.js"
            //    );
            //bundles.Add(jsBundle);

        }
    }
}
