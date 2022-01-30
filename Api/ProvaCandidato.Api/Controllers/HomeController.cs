using ProvaCandidato.Domain.Health;
using System.Web.Http;

namespace ProvaCandidato.Web.Controllers
{
    [RoutePrefix("Health")]
    public class HealthController : ApiController
    {
        private readonly IHealthService _healthService;

        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        [HttpGet, Route("Ping")]
        public IHttpActionResult Ping()
        {
            var health = _healthService.Ping();

            return Ok(health);
        }
    }
}
