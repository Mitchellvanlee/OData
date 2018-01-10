using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Query;
using System.Web.OData.Routing.Conventions;
using Microsoft.OData;
using Microsoft.OData.UriParser;
using ODataPOC.Models;

namespace ODataPOC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.AddODataQueryFilter(new EnableQueryAttribute()
            {
                MaxExpansionDepth = 10,
                PageSize = 100,
                MaxTop = 100,
                AllowedFunctions = AllowedFunctions.AllFunctions,
                AllowedArithmeticOperators = AllowedArithmeticOperators.All,
                AllowedQueryOptions = AllowedQueryOptions.All

            });
            config.Expand().Count().Filter().Select().MaxTop(100).OrderBy();

            ODataModelBuilder builder = new ODataConventionModelBuilder(config);
            builder.Namespace = "ODataPOC";
            builder.EntitySet<Verkoper>("Verkopers");
            builder.EntitySet<SubAgent>("SubAgenten");
            builder.EntitySet<Contract>("Contracten");

            var routingConventions = ODataRoutingConventions
                .CreateDefaultWithAttributeRouting("odata", config)
                .AsEnumerable();

            var route = config.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                configureAction: containerBuilder => containerBuilder
                    .AddService(ServiceLifetime.Singleton, sp => builder.GetEdmModel())
                    .AddService(ServiceLifetime.Singleton, sp => routingConventions)
                    .AddService(ServiceLifetime.Singleton, typeof(ODataUriResolver), sp => new StringAsEnumResolver { EnableCaseInsensitive = true })
            );

        }
    }
}