using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Beyond_Crisis_Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest()
        {
            // Do a permanent redirect if beyondcrisisfilm.com is accessed instead of www.
            HttpApplication application = (HttpApplication)this;
            HttpContext context = application.Context;

            if (context.Request.Url.Host == "beyondcrisisfilm.com"
                || context.Request.Url.Host == "beyondcrisisfilm.ca"
                || context.Request.Url.Host == "www.beyondcrisisfilm.ca")
            {
                context.Response.Clear();
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", "http://www.beyondcrisisfilm.com" + context.Request.RawUrl);
            }

            context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
            HttpContext.Current.Response.AppendHeader("Content-encoding", "gzip");
            HttpContext.Current.Response.AppendHeader("Cache-Control", "public, max-age=31104000");
            HttpContext.Current.Response.Cache.VaryByHeaders["Accept-encoding"] = true;
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
