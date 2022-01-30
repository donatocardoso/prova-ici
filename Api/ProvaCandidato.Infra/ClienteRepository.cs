using Dapper;
using ProvaCandidato.Domain.Cliente;
using ProvaCandidato.Domain.Cliente.Dtos;
using ProvaCandidato.Utils.Commons;
using ProvaCandidato.Utils.Connections;
using System.Collections.Generic;
using System.Linq;

namespace ProvaCandidato.Repositories.Cliente
{
    public class ClienteRepository : SqlServerConnection, IClienteRepository
    {
        public ClienteRepository()
        {
        }

        public IReturn<IEnumerable<ClienteDto>> GetAll()
        {
            var clientes = _db.Query<ClienteDto>(@"");

            if (!clientes.Any())
            {
                return Return.Fail<IEnumerable<ClienteDto>>("Nenhuma cliente encontrada");
            }

            return Return.Success($"Total de {clientes.Count()} cliente(s) encontrada(s)", clientes);
        }

        public IReturn<ClienteDto> GetByCodigo(int codigo)
        {
            var cliente = _db.QueryFirstOrDefault<ClienteDto>(@"");

            if (cliente == null)
            {
                return Return.Fail<ClienteDto>("Nenhuma cliente encontrada");
            }

            return Return.Success($"Cliente encontrada", cliente);
        }

        public IReturn<ClienteDto> GetByNome(string nome)
        {
            var cliente = _db.QueryFirstOrDefault<ClienteDto>(@"");

            if (cliente == null)
            {
                return Return.Fail<ClienteDto>("Nenhuma cliente encontrada");
            }

            return Return.Success($"Cliente encontrada", cliente);
        }

        public IReturn Post(ClienteDto cliente)
        {
            var exist = GetByNome(cliente.Nome);

            if (exist != null)
            {
                return Return.Fail("Cliente já cadastrada");
            }

            _db.Execute(@"");

            return Return.Success("Cliente cadastrada");
        }

        public IReturn Put(int codigo, ClienteDto cliente)
        {
            var old = GetByCodigo(codigo);

            if (!old.IsSuccess)
            {
                return Return.Fail("Cliente não encontrada");
            }

            _db.Execute(@"");

            return Return.Success("Cliente atualizada");
        }

        public IReturn Delete(int codigo)
        {
            var old = GetByCodigo(codigo);

            if (!old.IsSuccess)
            {
                return Return.Fail("Cliente não encontrada");
            }

            _db.Execute(@"");

            return Return.Success("Cliente deletada");
        }
    }
}
