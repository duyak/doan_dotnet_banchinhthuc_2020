using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Website_StorePhone3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             "Shop", "Shop/{action}/{id}",
             defaults: new { controller = "Shop", action = "List", id = UrlParameter.Optional }
          );

            routes.MapRoute(

                   "chitiet", "chitiet/{action}/{id}",
                   defaults: new { controller = "ProductDetail", action = "ProductDetail", id = UrlParameter.Optional }

            );
            routes.MapRoute(

                  "ShoppingCart", "ShoppingCart/{action}/{id}",
                  defaults: new { controller = "Cart", action = "Cart", id = UrlParameter.Optional }

           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
