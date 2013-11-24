using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using FluentSecurity;
using RealEstate.Web.Controllers;

namespace RealEstate.Web.Infrastructure
{
    public static class SecurityHelpers
    {
        public static IEnumerable<object> UserRoles()
        {
            var listRoles = new List<string> {"Admin", "User"};
            return listRoles;
        }
    }

    public static class FluentSecurityConfig
    {
        public static void Configure()
        {
            SecurityConfigurator.Configure(configuration =>
            {
                configuration.GetAuthenticationStatusFrom(() => HttpContext.Current.User.Identity.IsAuthenticated);
                configuration.GetRolesFrom(SecurityHelpers.UserRoles);

                configuration.ForAllControllers().DenyAnonymousAccess();
                configuration.For<AccountController>(x => x.LogIn()).Ignore();
                configuration.For<AccountController>(x => x.Register()).Ignore();
                //configuration.For<DiskController>(x => x.Index()).RequireRole(new object[] { "Admin" });
                configuration.ResolveServicesUsing(type =>
                {
                    if (type == typeof(IPolicyViolationHandler))
                    {
                        var types = Assembly
                            .GetAssembly(typeof(MvcApplication))
                            .GetTypes()
                            .Where(x => typeof(IPolicyViolationHandler).IsAssignableFrom(x)).ToList();

                        var handlers = types.Select(t => Activator.CreateInstance(t) as IPolicyViolationHandler).ToList();

                        return handlers;
                    }
                    return Enumerable.Empty<object>();
                });
            });

        }
    }
}