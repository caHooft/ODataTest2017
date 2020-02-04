using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ODataTest2017.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace ODataTest2017
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Standart Code
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute
            (
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Code I added
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            config.MapODataServiceRoute
                (
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel()
                );
        }
    }
}
