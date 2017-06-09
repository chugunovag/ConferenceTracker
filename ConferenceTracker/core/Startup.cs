using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;

namespace ConferenceTracker.core
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            appBuilder.UseWebApi(config);

        }
    }
}