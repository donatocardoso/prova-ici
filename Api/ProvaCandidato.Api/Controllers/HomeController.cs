using System.Web.Http;

namespace ProvaCandidato.Controllers
{
    [RoutePrefix("Health")]
    public class HealthController : ApiController
    {
        [HttpGet, Route("Ping")]
        public IHttpActionResult Ping()
        {
            return Ok();
        }
    }
}
