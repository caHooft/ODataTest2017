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
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");

            builder.EntitySet<Supplier>("Suppliers");
            config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());

            builder.Namespace = "ODataTest2017";
            builder.EntityType<Product>() .Action("Rate") .Parameter<int>("Rating");

        }
    }
}
