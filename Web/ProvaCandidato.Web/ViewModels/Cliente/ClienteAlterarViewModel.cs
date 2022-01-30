using ProvaCandidato.Application.ApiProvaCandidato.Cidade.Models;
using ProvaCandidato.Application.ApiProvaCandidato.Cliente.Models;
using System.Collections.Generic;

namespace ProvaCandidato.Web.ViewModels.Cliente
{
    public class ClienteAlterarViewModel
    {
        public IList<CidadeModel> Cidades { get; set; }
        public ClienteModel Cliente { get; set; }
    }
}
