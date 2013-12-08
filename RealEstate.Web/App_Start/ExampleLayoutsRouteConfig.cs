using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapMvcSample.Controllers;
using NavigationRoutes;
using RealEstate.Domain.Entities;
using RealEstate.Web.Controllers;

namespace BootstrapMvcSample
{
    public class ExampleLayoutsRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapNavigationRoute<PropertiesController>("Search", c => c.ListProperties())
                .AddChildRoute<AccountController>("Search Profile", c => c.SearchProfile())
                .AddChildRoute<PropertiesController>("Search for Property", ctx => ctx.SearchProperty());

            routes.MapNavigationRoute<AccountController>("Account", c =>c.Index())
                .AddChildRoute<AccountController>("My Profile", c => c.MyProfile())
                .AddChildRoute<AccountController>("Sign out", c => c.LogOut());
                ;
        }
    }
}
