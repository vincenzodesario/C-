using ProductService.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData.Batch;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Routing.Conventions;
using System.Web.Http.OData.Extensions;
using System.Web.Http.Controllers;
using System.Web.Http.OData.Routing;

namespace ProductService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Supplier>("Suppliers");
            builder.EntitySet<ProductRating>("Ratings");
            builder.EntitySet<Brand>("Brands");
            ActionConfiguration rateProduct = builder.Entity<Product>().Action("RateProduct");
            rateProduct.Parameter<int>("Rating");
            rateProduct.Returns<double>();

            var model = builder.GetEdmModel();
            HttpServer server = new HttpServer(config);

            config.Routes.MapODataServiceRoute("odata", "", model);
            config.EnableQuerySupport();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}