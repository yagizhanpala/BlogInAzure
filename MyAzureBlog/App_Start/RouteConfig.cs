using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyAzureBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Seo URL amaçlı: 09.12.2014
            routes.MapRoute(
                name: "Category",
                url: "Category",
                defaults: new { controller = "Category", action = "Index" }
            );

            routes.MapRoute(
                name: "Entry",
                url: "Entry",
                defaults: new { controller = "Entry", action = "Index" }
            );

            routes.MapRoute(
                name: "ReadSeo",
                url: "{seourl}",
                defaults: new { controller = "Home", action = "Read" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
