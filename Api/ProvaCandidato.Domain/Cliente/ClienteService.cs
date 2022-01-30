using ProvaCandidato.Domain.Cliente.Dtos;
using ProvaCandidato.Utils.Commons;
using System;
using System.Collections.Generic;

namespace ProvaCandidato.Domain.Cliente
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IReturn<IEnumerable<ClienteDto>> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public IReturn<ClienteDto> GetByCodigo(int codigo)
        {
            return _clienteRepository.GetByCodigo(codigo);
        }

        public IReturn<ClienteDto> GetByNome(string nome)
        {
            return _clienteRepository.GetByNome(nome);
        }

        public IReturn<ClienteDto> Post(string nome, DateTime dataNascimento, int cidadeId)
        {
            return _clienteRepository.Post(new ClienteDto()
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                CidadeId = cidadeId,
            });
        }

        public IReturn Put(int codigo, ClienteDto cliente)
        {
            return _clienteRepository.Put(codigo, cliente);
        }

        public IReturn Delete(int codigo)
        {
            return _clienteRepository.Delete(codigo);
        }
    }
}
