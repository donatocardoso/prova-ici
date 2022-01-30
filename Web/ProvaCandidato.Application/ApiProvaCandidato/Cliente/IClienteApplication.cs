using ProvaCandidato.Application.ApiProvaCandidato.Cliente.Models;
using ProvaCandidato.Utils.Commons;
using System.Collections.Generic;

namespace ProvaCandidato.Application.ApiProvaCandidato.Cliente
{
    public interface IClienteApplication
    {
        IReturn<IEnumerable<ClienteModel>> GetAll();
        IReturn<ClienteModel> GetByCodigo(int codigo);
        IReturn<ClienteModel> GetByNome(string nome);
        IReturn Post(ClienteModel cliente);
        IReturn Put(int codigo, ClienteModel cliente);
        IReturn Delete(int codigo);
    }
}
