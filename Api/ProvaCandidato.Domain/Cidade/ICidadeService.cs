using ProvaCandidato.Domain.Cidade.Dtos;
using ProvaCandidato.Utils.Commons;
using System.Collections.Generic;

namespace ProvaCandidato.Domain.Cidade
{
    public interface ICidadeService
    {
        IReturn<IEnumerable<CidadeDto>> GetAll();
        IReturn<CidadeDto> GetByCodigo(int codigo);
        IReturn<CidadeDto> GetByNome(string nome);
        IReturn Post(CidadeDto cidade);
        IReturn Put(int codigo, CidadeDto cidade);
        IReturn Delete(int codigo);
    }
}
