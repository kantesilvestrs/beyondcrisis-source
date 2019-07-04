using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;
using BundleTransformer.Yui.Minifiers;
using BundleTransformer.Core.Transformers;

namespace Beyond_Crisis_Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Styles

            var styleBundle = new StyleBundle("~/client/css");
            List<string> styleList = new List<string>
            {
                //"~/Content/client/css/site.css",
                "~/Content/map/assets/smartonclimate/css/smartonclimate.css",
                "~/Content/map/assets/ourstory/css/ourstory.css",
                "~/Content/map/assets/credits/css/credits.css",
                "~/Content/map/assets/loadingScreen/css/loadingScreen.css",
                "~/Content/map/sidepanels/smartonclimate/css/smartonclimate_sidepanel.css",
                "~/Content/map/sidepanels/ourstory/css/ourstory_sidepanel.css",
                "~/Content/map/sidepanels/credits/css/credits_sidepanel.css",
                "~/Content/map/other/videostrip/css/videostrip.css",
                "~/Content/map/other/videostrip/css/video-background.css",
                "~/Content/map/other/videostrip/css/youtube-video.css",
                "~/Content/map/assets/base/css/base.css",
                "~/Content/map/assets/base/css/socialinks.css",
                "~/Content/client/css/perfectScrollbar/css/perfect-scrollbar.css",
                "~/Content/map/assets/facesofclimate/css/facesofclimate.css",
                "~/Content/client/css/lazyYT.css"
            };

            styleBundle.Include(styleList.ToArray()).Orderer = new CustomBundleOrderer();
            styleBundle.Transforms.Add(new StyleTransformer(new YuiCssMinifier()));

            // TODO: add css transformer

            bundles.Add(styleBundle);

            #endregion

            #region Scripts

            var scriptBundle = new ScriptBundle("~/client/js");
            List<string> scriptList = new List<string>
            {
                // Independent modules
                "~/Content/client/js/lib/jquery-2.1.3.js",
                "~/Content/client/js/lib/lodash.js",
                "~/Content/client/js/lib/TweenMax/TweenMax.js",
                "~/Content/client/js/lib/PxLoader.js",
                "~/Content/client/js/lib/PxLoaderImage.js",


                // Dependant modules
                // Tween Max Plugins
                "~/Content/client/js/lib/perfectScrollbar/js/perfect-scrollbar.jquery.js",
                "~/Content/client/js/lib/TweenMax/TimelineMax.js",
                "~/Content/client/js/lib/TweenMax/TextPlugin.js",
                "~/Content/client/js/lib/TweenMax/ScrollToPlugin.js",
                "~/Content/client/js/lib/TweenMax/RoundPropsPlugin.js",
                "~/Content/client/js/lib/TweenMax/DirectionalRotationPlugin.js",
                "~/Content/client/js/lib/TweenMax/CSSRulePlugin.js",
                "~/Content/client/js/lib/TweenMax/ColorPropsPlugin.js",
                "~/Content/client/js/lib/TweenMax/AttrPlugin.js",
                "~/Content/client/js/lib/TweenMax/Draggable.js",

                // Youtube
                //"~/Content/client/js/lib/YT_iframe_api.js",
                "~/Content/client/js/lib/lazyYT.js",

                // Require JS Modules
                "~/Content/client/js/lib/require.js"
            };

            scriptBundle.Include(scriptList.ToArray()).Orderer = new CustomBundleOrderer();

            scriptBundle.IncludeDirectory("~/Content/client/js/modules", "*.js", true);
            scriptBundle.IncludeDirectory("~/Content/client/js/cities", "*.js", true);

            scriptBundle.Include("~/Content/client/js/common.js");

            scriptBundle.Transforms.Add(new ScriptTransformer(new YuiJsMinifier()));

            bundles.Add(scriptBundle);

            #endregion

            bundles.IgnoreList.Clear();
            BundleTable.EnableOptimizations = true;
        }
    }

    class CustomBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
