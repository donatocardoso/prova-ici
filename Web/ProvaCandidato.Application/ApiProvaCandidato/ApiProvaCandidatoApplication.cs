using ProvaCandidato.Application.ApiProvaCandidato.Cidade;
using ProvaCandidato.Application.ApiProvaCandidato.Cliente;

namespace ProvaCandidato.Application.ApiProvaCandidato
{
    public class ApiProvaCandidatoApplication : IApiProvaCandidatoApplication
    {
        public ICidadeApplication Cidade => new CidadeApplication();

        public IClienteApplication Cliente => new ClienteApplication();
    }
}
