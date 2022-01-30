using Dapper;
using ProvaCandidato.Domain.Cidade;
using ProvaCandidato.Domain.Cidade.Dtos;
using ProvaCandidato.Utils.Commons;
using ProvaCandidato.Utils.Connections;
using System.Collections.Generic;
using System.Linq;

namespace ProvaCandidato.Repositories.Cidade
{
    public class CidadeRepository : SqlServerConnection, ICidadeRepository
    {
        public CidadeRepository()
        {
        }

        public IReturn<IEnumerable<CidadeDto>> GetAll()
        {
            var cidades = _db.Query<CidadeDto>(@"
                SELECT 
                    [Codigo],
                    [Nome]
                FROM [dbo].[Cidade]
            ");

            if (!cidades.Any())
            {
                return Return.Fail<IEnumerable<CidadeDto>>("Nenhuma cidade encontrada");
            }

            return Return.Success($"Total de {cidades.Count()} cidade(s) encontrada(s)", cidades);
        }

        public IReturn<CidadeDto> GetByCodigo(int codigo)
        {
            var cidade = _db.QueryFirstOrDefault<CidadeDto>(@"
                SELECT 
                    [Codigo],
                    [Nome]
                FROM [dbo].[Cidade]
                WHERE [Codigo] = @Codigo
            ", new
            {
                Codigo = codigo,
            });

            if (cidade == null)
            {
                return Return.Fail<CidadeDto>("Nenhuma cidade encontrada");
            }

            return Return.Success($"Cidade encontrada", cidade);
        }

        public IReturn<CidadeDto> GetByNome(string nome)
        {
            var cidade = _db.QueryFirstOrDefault<CidadeDto>(@"
                SELECT 
                    [Codigo],
                    [Nome]
                FROM [dbo].[Cidade]
                WHERE [Nome] LIKE @Nome
            ", new
            {
                Nome = $"%{nome}%",
            });

            if (cidade == null)
            {
                return Return.Fail<CidadeDto>("Nenhuma cidade encontrada");
            }

            return Return.Success($"Cidade encontrada", cidade);
        }

        public IReturn<CidadeDto> Post(CidadeDto cidade)
        {
            var exist = GetByNome(cidade.Nome);

            if (exist.IsSuccess && exist.Content != null)
            {
                return Return.Fail<CidadeDto>("Cidade já cadastrada");
            }

            _db.Execute(@"
                INSERT INTO [dbo].[Cidade]
                       ([Nome])
                 VALUES
                       (@Nome)
            ", new
            {
                Nome = cidade.Nome,
            });

            return Return.Success("Cidade já cadastrada", exist.Content);
        }

        public IReturn Put(int codigo, CidadeDto cidade)
        {
            var old = GetByCodigo(codigo);

            if (!old.IsSuccess)
            {
                return Return.Fail("Cidade não encontrada");
            }

            _db.Execute(@"
                UPDATE [dbo].[Cidade]
                    SET [Nome] = @Nome
                WHERE [Codigo] = @Codigo
            ", new
            {
                Codigo = codigo,
                Nome = cidade.Nome,
            });

            return Return.Success("Cidade atualizada");
        }

        public IReturn Delete(int codigo)
        {
            var old = GetByCodigo(codigo);

            if (!old.IsSuccess)
            {
                return Return.Fail("Cidade não encontrada");
            }

            _db.Execute(@"
                DELETE FROM [dbo].[Cidade]                    
                    WHERE [Codigo] = @Codigo
            ", new
            {
                Codigo = codigo,
            });

            return Return.Success("Cidade deletada");
        }
    }
}
