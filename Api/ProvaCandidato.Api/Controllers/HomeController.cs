using System;
using System.Web.Http;

namespace ProvaCandidato.Web.Controllers
{
    [RoutePrefix("Health")]
    public class HealthController : ApiController
    {
        [HttpGet, Route("Ping")]
        public IHttpActionResult Ping()
        {
            return Ok(new
            {
                DateTime = DateTime.Now
            });
        }
    }
}
