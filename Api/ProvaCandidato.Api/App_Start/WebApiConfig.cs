﻿using ProvaCandidato.Api.Resolver;
using ProvaCandidato.Domain.Health;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;

namespace ProvaCandidato.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            config.DependencyResolver = new UnityResolver(DependencyInjection());
        }

        private static UnityContainer DependencyInjection()
        {
            var container = new UnityContainer();

            // Services

            container.RegisterType<IHealthService, HealthService>();

            // Repositories

            return container;
        }
    }
}