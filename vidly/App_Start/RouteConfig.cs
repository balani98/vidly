using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //attribute routing
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //                 "MoviesByReleaseDate",//name of route
            //                 "movies/released/{year}/{month}",//url
            //                 new { controller = "movies", action = "ByReleaseDate" },//method and controller name
            //                 new {year=@"\d{4}",month=@"\d{2}"}//constraints
            //                 // new { year = @"2015|2016", month = @"\d{2}" }
            //                 );
           routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
