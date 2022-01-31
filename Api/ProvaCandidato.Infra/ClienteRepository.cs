using Dapper;
using ProvaCandidato.Domain.Cidade.Dtos;
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
            var clientes = _db.Query<ClienteDto, CidadeDto, ClienteDto>(@"
                SELECT 
                    [CL].[Codigo],
                    [CL].[Nome],
                    [CL].[DataNascimento],
                    [CL].[CidadeId],
                    [CL].[Ativo],
                    
                    [CI].[Codigo],
                    [CI].[Nome]

                FROM [dbo].[Cliente] AS [CL]
                    INNER JOIN [dbo].[Cidade] AS [CI]
                        ON [CI].[Codigo] = [CL].[CidadeId]
                WHERE [CL].[Ativo] = 1
            ",
            (cli, cid) =>
            {
                cli.Cidade = cid;

                return cli;
            },
            splitOn: "Codigo");

            if (!clientes.Any())
            {
                return Return.Fail<IEnumerable<ClienteDto>>("Nenhum cliente encontrado");
            }

            return Return.Success($"Total de {clientes.Count()} cliente(s) encontrado(s)", clientes);
        }

        public IReturn<ClienteDto> GetByCodigo(int codigo)
        {
            var cliente = _db.Query<ClienteDto, CidadeDto, ClienteDto>(@"
                SELECT 
                    [CL].[Codigo],
                    [CL].[Nome],
                    [CL].[DataNascimento],
                    [CL].[CidadeId],
                    [CL].[Ativo],
                    
                    [CI].[Codigo],
                    [CI].[Nome]

                FROM [dbo].[Cliente] AS [CL]
                    INNER JOIN [dbo].[Cidade] AS [CI]
                        ON [CI].[Codigo] = [CL].[CidadeId]
                WHERE [CL].[Ativo] = 1
                    AND [CL].[Codigo] = @Codigo
            ",
            (cli, cid) =>
            {
                cli.Cidade = cid;

                return cli;
            },
            new
            {
                Codigo = codigo,
            },
            splitOn: "Codigo").FirstOrDefault();

            if (cliente == null)
            {
                return Return.Fail<ClienteDto>("Nenhum cliente encontrado");
            }

            return Return.Success($"Cliente encontrado", cliente);
        }

        public IReturn<ClienteDto> GetByNome(string nome)
        {
            var cliente = _db.Query<ClienteDto, CidadeDto, ClienteDto>(@"
                SELECT 
                    [CL].[Codigo],
                    [CL].[Nome],
                    [CL].[DataNascimento],
                    [CL].[CidadeId],
                    [CL].[Ativo],
                    
                    [CI].[Codigo],
                    [CI].[Nome]

                FROM [dbo].[Cliente] AS [CL]
                    INNER JOIN [dbo].[Cidade] AS [CI]
                        ON [CI].[Codigo] = [CL].[CidadeId]
                WHERE [CL].[Ativo] = 1
                    AND [CL].[Nome] LIKE @Nome
            ",
            (cli, cid) =>
            {
                cli.Cidade = cid;

                return cli;
            },
            new
            {
                Nome = $"%{nome}%",
            },
            splitOn: "Codigo").FirstOrDefault();

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
            ", new
            {
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento?.ToString("yyyy-MM-dd"),
                CidadeId = cliente.CidadeId,
            });

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
