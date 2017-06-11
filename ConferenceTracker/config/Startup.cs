using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;

namespace ConferenceTracker.config {
    /// <summary>
    ///     Конфигурация веб сервера. JSON используется по умолчанию, добавим только мапинг роутов по атрибутам и
    ///     CamelCasePropertyNames на всякий случай
    /// </summary>
    public class Startup {
        public void Configuration(IAppBuilder appBuilder) {
            var config = new HttpConfiguration();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            config.MapHttpAttributeRoutes();
            appBuilder.UseWebApi(config);
        }
    }
}