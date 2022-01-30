using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ProvaCandidato.Api.Startup))]

namespace ProvaCandidato.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
        }
    }
}
