using ProvaCandidato.Domain.Cliente.Dtos;
using ProvaCandidato.Utils.Commons;
using System;
using System.Collections.Generic;

namespace ProvaCandidato.Domain.Cliente
{
    public interface IClienteService
    {
        IReturn<IEnumerable<ClienteDto>> GetAll();
        IReturn<ClienteDto> GetByCodigo(int codigo);
        IReturn<ClienteDto> GetByNome(string nome);
        IReturn<ClienteDto> Post(string nome, DateTime dataNascimento, int cidadeId);
        IReturn Put(int codigo, ClienteDto cliente);
        IReturn Delete(int codigo);
    }
}
