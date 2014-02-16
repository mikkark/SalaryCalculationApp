using System.Web.Mvc;
using System.Web.Routing;

namespace mikkark.SCA.Client.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{resource}.html");

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Home", id = UrlParameter.Optional}
                );
        }
    }
}
