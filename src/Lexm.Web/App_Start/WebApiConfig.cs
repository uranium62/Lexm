using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Lexm.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "TreeApi",
                "api/tree/{query}",
                new { controller = "Tree" }
            );
        }

        public static void Configure()
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
