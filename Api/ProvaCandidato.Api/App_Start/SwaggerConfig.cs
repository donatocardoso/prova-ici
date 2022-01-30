using ProvaCandidato.Api;
using Swashbuckle.Application;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ProvaCandidato.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.PrettyPrint();
                        c.Schemes(new[] { "http", "https" });

                        c.SingleApiVersion("v1", "ProvaCandidato.Api");

                        c.BasicAuth("basic").Description("Basic HTTP Authentication");
                    })
                .EnableSwaggerUi();
        }
    }
}
