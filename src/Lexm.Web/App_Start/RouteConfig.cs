using System.Web.Mvc;
using System.Web.Routing;

namespace Lexm.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("index.html");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
    }
}
