using ProvaCandidato.Application.ApiProvaCandidato.Cidade;
using ProvaCandidato.Application.ApiProvaCandidato.Cliente;

namespace ProvaCandidato.Application.ApiProvaCandidato
{
    public class ApiProvaCandidatoApplication
    {
        public CidadeApplication Cidade => new CidadeApplication();
        public ClienteApplication Cliente => new ClienteApplication();
    }
}
