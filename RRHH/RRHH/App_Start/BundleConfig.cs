using System.Web;
using System.Web.Optimization;

namespace RRHH
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/javascripts").Include(
             "~/Content/assets/plugins/jquery-1.8.3.min.js",
             "~/Content/assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js",
             "~/Content/assets/plugins/boostrapv3/js/bootstrap.min.js",
             "~/Content/assets/plugins/breakpoints.js",
             "~/Content/assets/plugins/jquery-unveil/jquery.unveil.min.js",
             "~/Content/assets/plugins/jquery-block-ui/jqueryblockui.js",
             "~/Content/assets/plugins/jquery-scrollbar/jquery.scrollbar.min.js",
             "~/Content/assets/plugins/pace/pace.min.js",
             "~/Content/assets/plugins/jquery-numberAnimate/jquery.animateNumbers.js",
             "~/Content/assets/js/core.js",
             "~/Content/assets/js/chat.js",
             "~/Content/assets/js/demo.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/plugins/pace/pace-theme-flash.css",
                      "~/Content/assets/plugins/jquery-scrollbar/jquery.scrollbar.css",
                      "~/Content/assets/plugins/boostrapv3/css/bootstrap.min.css",
                      "~/Content/assets/plugins/boostrapv3/css/bootstrap-theme.min.css",
                      "~/Content/assets/plugins/font-awesome/css/font-awesome.css",
                      "~/Content/assets/css/animate.min.css",
                      "~/Content/assets/css/style.css",
                      "~/Content/assets/css/responsive.css",
                      "~/Content/assets/css/custom-icon-set.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqwidgets").Include(
            "~/Scripts/jqxcore.js",
            "~/Scripts/jqxdata.js",
            "~/Scripts/jqxgrid.js",
            "~/Scripts/jqxgrid.selection.js",
            "~/Scripts/jqxgrid.pager.js",
            "~/Scripts/jqxlistbox.js",
            "~/Scripts/jqxbuttons.js",
            "~/Scripts/jqxscrollbar.js",
            "~/Scripts/jqxdatatable.js",
            "~/Scripts/jqxtreegrid.js",
            "~/Scripts/jqxmenu.js",
            "~/Scripts/jqxcalendar.js",
            "~/Scripts/jqxgrid.sort.js",
            "~/Scripts/jqxgrid.filter.js",
            "~/Scripts/jqxdatetimeinput.js",
            "~/Scripts/jqxdropdownlist.js",
            "~/Scripts/jqxslider.js",
            "~/Scripts/jqxeditor.js",
            "~/Scripts/jqxinput.js",
            "~/Scripts/jqxdraw.js",
            "~/Scripts/jqxchart.core.js",
            "~/Scripts/jqxchart.rangeselector.js",
            "~/Scripts/jqxtree.js",
            "~/Scripts/globalize.js",
            "~/Scripts/jqxbulletchart.js",
            "~/Scripts/jqxcheckbox.js",
            "~/Scripts/jqxradiobutton.js",
            "~/Scripts/jqxvalidator.js",
            "~/Scripts/jqxpanel.js",
            "~/Scripts/jqxpasswordinput.js",
            "~/Scripts/jqxnumberinput.js",
            "~/Scripts/jqxcombobox.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/jqx.base.css",
                "~/Content/jqx.arctic.css",
                "~/Content/jqx.black.css",
                "~/Content/jqx.bootstrap.css",
                "~/Content/jqx.classic.css",
                "~/Content/jqx.darkblue.css",
                "~/Content/jqx.energyblue.css",
                "~/Content/jqx.fresh.css",
                "~/Content/jqx.highcontrast.css",
                "~/Content/jqx.metro.css",
                "~/Content/jqx.metrodark.css",
                "~/Content/jqx.office.css",
                "~/Content/jqx.orange.css",
                "~/Content/jqx.shinyblack.css",
                "~/Content/jqx.summer.css",
                "~/Content/jqx.web.css",
                "~/Content/jqx.ui-darkness.css",
                "~/Content/jqx.ui-lightness.css",
                "~/Content/jqx.ui-le-frog.css",
                "~/Content/jqx.ui-overcast.css",
                "~/Content/jqx.ui-redmond.css",
                "~/Content/jqx.ui-smoothness.css",
                "~/Content/jqx.ui-start.css",
                "~/Content/jqx.ui-sunny.css",
                "~/Content/bootstrap.css",
                "~/Content/site.css"
                ));
        }
    }
}
