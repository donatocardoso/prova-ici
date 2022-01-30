using ProvaCandidato.Domain.Health;
using System.Web.Http;

namespace ProvaCandidato.Api.Controllers
{
    [RoutePrefix("api/v1/Health")]
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
