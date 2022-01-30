using ProvaCandidato.Domain.Cidade;
using ProvaCandidato.Domain.Cliente.Dtos;
using ProvaCandidato.Utils.Commons;
using System.Collections.Generic;

namespace ProvaCandidato.Domain.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(ICidadeRepository cidadeRepository, IClienteRepository clienteRepository)
        {
            _cidadeRepository = cidadeRepository;
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

        public IReturn Post(ClienteDto cliente)
        {
            var cidadeExists = _cidadeRepository.GetByCodigo(cliente.CidadeId);

            if (!cidadeExists.IsSuccess)
            {
                return Return.Fail("Código de cidade inválido");
            }

            return _clienteRepository.Post(cliente);
        }

        public IReturn Put(int codigo, ClienteDto cliente)
        {
            var cidadeExists = _cidadeRepository.GetByCodigo(cliente.CidadeId);

            if (!cidadeExists.IsSuccess)
            {
                return Return.Fail("Código de cidade inválido");
            }

            return _clienteRepository.Put(codigo, cliente);
        }

        public IReturn Delete(int codigo)
        {
            return _clienteRepository.Delete(codigo);
        }
    }
}
