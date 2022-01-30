using ProvaCandidato.Domain.Cliente.Dtos;
using ProvaCandidato.Utils.Commons;
using System.Collections.Generic;

namespace ProvaCandidato.Domain.Cliente
{
    public interface IClienteRepository
    {
        IReturn<IEnumerable<ClienteDto>> GetAll();
        IReturn<ClienteDto> GetByCodigo(int codigo);
        IReturn<ClienteDto> GetByNome(string nome);
        IReturn<ClienteDto> Post(ClienteDto cliente);
        IReturn Put(int codigo, ClienteDto cliente);
        IReturn Delete(int codigo);
    }
}
