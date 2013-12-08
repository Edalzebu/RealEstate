using System.Web.Mvc;
using System.Web.Routing;

namespace RealEstate.Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("LogIn", "Account/LogIn", new {controller = "Account", action = "LogIn"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Properties", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}