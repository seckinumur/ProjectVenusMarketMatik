using MarketMatikAPI.Attributes;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MarketMatikAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors(); //Herkes Bağlanabilir
            // Web API routes
            config.MapHttpAttributeRoutes(); 
            config.Filters.Add(new HataAttributes()); //Hata Yönetimi

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; //Düzgün json Formatı

            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); json kamel kase şeklinde gelmesi
        }
    }
}
