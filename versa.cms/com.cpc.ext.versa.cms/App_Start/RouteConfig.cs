using com.carzapc.core.web;
using System.Web.Mvc;
using System.Web.Routing;

namespace com.cpc.ext.versa.cms
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            Utils.Ruta.LoadRoutes(routes);
        }
    }
}
