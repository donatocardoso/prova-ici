using ProvaCandidato.Domain.Health.Dtos;
using ProvaCandidato.Utils.Commons;
using ProvaCandidato.Utils.Environment;
using System;

namespace ProvaCandidato.Domain.Health
{
    public class HealthService : IHealthService
    {
        public HealthService()
        {
        }

        public IReturn<HealthDto> Ping()
        {
            return Return.Success("Api ProvaCandidato Online...", new HealthDto()
            {
                Environment = ApiEnvironment.Environment.ToString(),
                DateTime = DateTime.Now,
            });
        }
    }
}
