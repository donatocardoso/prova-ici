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
            var clientes = _db.Query<ClienteDto>(@"
                SELECT 
                    [Codigo],
                    [Nome],
                    [DataNascimento],
                    [CidadeId],
                    [Ativo]
                FROM [dbo].[Cliente]
                WHERE [Ativo] = 1
            ");

            if (!clientes.Any())
            {
                return Return.Fail<IEnumerable<ClienteDto>>("Nenhum cliente encontrado");
            }

            return Return.Success($"Total de {clientes.Count()} cliente(s) encontrado(s)", clientes);
        }

        public IReturn<ClienteDto> GetByCodigo(int codigo)
        {
            var cliente = _db.QueryFirstOrDefault<ClienteDto>(@"
                SELECT 
                    [Codigo],
                    [Nome],
                    [DataNascimento],
                    [CidadeId],
                    [Ativo]
                FROM [dbo].[Cliente]
                WHERE [Ativo] = 1
                    AND [Codigo] = @Codigo
            ", new
            {
                Codigo = codigo,
            });

            if (cliente == null)
            {
                return Return.Fail<ClienteDto>("Nenhum cliente encontrado");
            }

            return Return.Success($"Cliente encontrado", cliente);
        }

        public IReturn<ClienteDto> GetByNome(string nome)
        {
            var cliente = _db.QueryFirstOrDefault<ClienteDto>(@"
                SELECT 
                    [Codigo],
                    [Nome],
                    [DataNascimento],
                    [CidadeId],
                    [Ativo]
                FROM [dbo].[Cliente]
                WHERE [Ativo] = 1
                    AND [Nome] LIKE @Nome
            ", new
            {
                Nome = $"%{nome}%",
            });

            if (cliente == null)
            {
                return Return.Fail<ClienteDto>("Nenhum cliente encontrado");
            }

            return Return.Success($"Cliente encontrado", cliente);
        }

        public IReturn Post(ClienteDto cliente)
        {
            var exist = GetByNome(cliente.Nome);

            if (exist.IsSuccess && exist.Content != null)
            {
                return Return.Fail("Cliente já cadastrado");
            }

            _db.Execute(@"
                INSERT INTO [dbo].[Cliente]
                           ([Nome],
                            [DataNascimento],
                            [CidadeId],
                            [Ativo])
                     VALUES
                           (@Nome,
                            @DataNascimento,
                            @CidadeId,
                            1)
            ", cliente);

            return Return.Success("Cliente cadastrado");
        }

        public IReturn Put(int codigo, ClienteDto cliente)
        {
            var old = GetByCodigo(codigo);

            if (!old.IsSuccess)
            {
                return Return.Fail("Cliente não encontrado");
            }

            _db.Execute(@"
                UPDATE [dbo].[Cliente]
                    SET [Nome] = @Nome,
                        [DataNascimento] = @DataNascimento,
                        [CidadeId] = @CidadeId
                WHERE [Codigo] = @Codigo
            ", cliente);

            return Return.Success("Cliente atualizado");
        }

        public IReturn Delete(int codigo)
        {
            var old = GetByCodigo(codigo);

            if (!old.IsSuccess)
            {
                return Return.Fail("Cliente não encontrado");
            }

            _db.Execute(@"
                UPDATE [dbo].[Cliente]
                    SET [Ativo] = 0
                WHERE [Codigo] = @Codigo
            ", new
            {
                Codigo = codigo,
            });

            return Return.Success("Cliente deletado");
        }
    }
}
