using ProvaCandidato.Application.ApiProvaCandidato.Cidade;
using ProvaCandidato.Application.ApiProvaCandidato.Cliente;

namespace ProvaCandidato.Application.ApiProvaCandidato
{
    public static class ApiProvaCandidato
    {
        public static CidadeApplication Cidade => new CidadeApplication();

        public static ClienteApplication Cliente => new ClienteApplication();
    }
}
