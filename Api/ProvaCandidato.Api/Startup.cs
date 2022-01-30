using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ProvaCandidato.Web.Startup))]

namespace ProvaCandidato.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
