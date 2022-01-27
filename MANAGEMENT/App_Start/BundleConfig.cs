using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MANAGEMENT.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
          "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                     "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                       "~/Scripts/moment.min.js"));
            //--- trouble   "~/Scripts/jquery.validate*",   --//

            bundles.Add(new ScriptBundle("~/bundles/tools").Include(
                                  //--"~/Content/ckeditor/ckeditor.js",
                                  "~/Scripts/dataTables.min.js",
                                  "~/Scripts/bootstrap-datetimepicker.min.js",
                                  "~/Scripts/bootstrapAlert.min.js",
                                  "~/Scripts/bootstrap-slider.min.js",
                                  "~/Scripts/bootstrap3-typeahead.min.js",
                                  "~/Scripts/jquerysession.js",
                                  //"~/Scripts/popper.min.js",
                                  "~/Scripts/main.min.js",
                                  "~/Scripts/Chart.min.js"));
            //-----------------"~/Scripts/jquery-ui.js", -------

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datetimepicker-build.less",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/bootstrap-slider.min.css",
                      "~/Content/style5.css",
                      "~/Content/ScrollTabla.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/main.min.css",
                      "~/Content/dataTables.min.css"));
            //-----------"~/Content/style.css", ScrollTabla.css------------
        }
    }
}