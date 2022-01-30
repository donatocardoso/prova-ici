using ProvaCandidato.Domain.Health.Dtos;
using ProvaCandidato.Utils.Commons;

namespace ProvaCandidato.Domain.Health
{
    public interface IHealthService
    {
        IReturn<HealthDto> Ping();
    }
}
