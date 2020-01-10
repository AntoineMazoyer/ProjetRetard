using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetRetard
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

            routes.MapRoute(
                name: "Connexion",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Connexion"}
            );

            routes.MapRoute(
                name: "FormulaireRetard",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "FormulaireRetard" }
            );
        }
    }
}
