using ProvaCandidato.Application.ApiProvaCandidato.Cidade;
using ProvaCandidato.Application.ApiProvaCandidato.Cliente;

namespace ProvaCandidato.Application.ApiProvaCandidato
{
    public interface IApiProvaCandidatoApplication
    {
        ICidadeApplication Cidade { get; }
        IClienteApplication Cliente { get; }
    }
}
