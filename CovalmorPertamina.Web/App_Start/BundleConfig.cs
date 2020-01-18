using System.Web;
using System.Web.Optimization;

namespace CovalmorPertamina.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/ionicons.min.css",
                "~/Content/AdminLTE.min.css",
                "~/Content/skin-black.min.css",
                "~/Content/Chart.min.css",
                "~/Content/datatables.min.css",
                "~/Content/select2.min.css",
                "~/Content/select2-bootstrap.min.css",
                "~/Content/main.css"
            ));


            bundles.Add(new ScriptBundle("~/Script/plugin").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/adminlte.min.js",
                "~/Scripts/Chart.min.js",
                "~/Scripts/datatables.min.js",
                "~/Scripts/dataTables.bootstrap.min.js",
                "~/Scripts/Validator.min.js",
                "~/Scripts/dataTables.buttons.js",
                "~/Scripts/buttons.html5.js",
                "~/Scripts/buttons.flash.js",
                "~/Scripts/buttons.print.js",
                "~/Scripts/buttons.colVis.js",
                "~/Scripts/buttons.bootstrap.js",
                "~/Scripts/select2.min.js",
                "~/Scripts/jquery.serializeToJSON.min.js"
            ));
        }
    }
}
