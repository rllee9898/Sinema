using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ElevenMovie
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //            routes.MapRoute(
            //           name: "TmdbApi",
            //           url: "TmdbApi/{id}/",
            //           defaults: new { controller = "TmdbApi", action = "GetMovie", id = "" },
            //           constraints: new { id = @"^[0-9]+$" }
            //);

            //            routes.MapRoute(
            //                name: "TmdbApiPaging",
            //                url: "TmdbApi/{title}/{page}",
            //                defaults: new { controller = "TmdbApi", action = "Index", title = "", page = "" },
            //                constraints: new { title = @"^[a-zA-Z]+$", page = @"^[0-9]+$" }
            //            );
            //        }
        }

    }
}