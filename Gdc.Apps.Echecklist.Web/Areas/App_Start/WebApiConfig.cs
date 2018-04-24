using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Gdc.Apps.Echecklist.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //跨域配置 cross orgin
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
