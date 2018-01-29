using System.Web;
using System.Web.Optimization;

namespace TuHaoQuNa.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //资源url
            var lib_url = DripOldDriver.Cache.MemoryCache.Cache.Get<string>("TuHaoQuNa.LibUrl", () => System.Configuration.ConfigurationManager.AppSettings["TuHaoQuNa.LibUrl"]);

            bundles.Add(new ScriptBundle("~/js/jquery", lib_url + "/js/jquery.js").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js/jqueryval", lib_url + "/js/jqueryval.js").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/js/statistics", lib_url+ "/js/statistics.js").Include(
                        "~/Scripts/statistics.js"));

            bundles.Add(new ScriptBundle("~/js/common", lib_url + "/js/common.js").Include(
                        "~/Scripts/common.js",
                        "~/Scripts/config.js",
                        "~/Scripts/common.film.js"));

            bundles.Add(new ScriptBundle("~/js/imagesloaded", lib_url+ "/js/imagesloaded.js").Include(
                        "~/Scripts/imagesloaded.pkgd.js"));

            bundles.Add(new ScriptBundle("~/js/masonry", lib_url + "/js/masonry.js").Include(
                        "~/Scripts/masonry.pkgd.js"));

            bundles.Add(new ScriptBundle("~/js/ReferreerKiller", lib_url + "/js/ReferreerKiller.js").Include(
                        "~/Scripts/ReferreerKiller.js"));

            bundles.Add(new ScriptBundle("~/layui/layui", lib_url + "/layui/layui.js").Include(
                        "~/layui/layui.js"));

            bundles.Add(new StyleBundle("~/css/main", lib_url + "/css/main.css").Include(
                      "~/Content/main.css",
                      "~/Content/theme.css",
                      "~/Content/customv.css"));

            bundles.Add(new StyleBundle("~/layui/css/layui", lib_url+ "/layui/css/layui.css").Include(
                      "~/layui/css/layui.css"));
        }
    }
}
