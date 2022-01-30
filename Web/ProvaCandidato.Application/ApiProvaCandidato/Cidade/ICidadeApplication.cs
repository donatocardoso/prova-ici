using ProvaCandidato.Application.ApiProvaCandidato.Cidade.Models;
using ProvaCandidato.Utils.Commons;
using System.Collections.Generic;

namespace ProvaCandidato.Application.ApiProvaCandidato.Cidade
{
    public interface ICidadeApplication
    {
        IReturn<IEnumerable<CidadeModel>> GetAll();
        IReturn<CidadeModel> GetByCodigo(int codigo);
        IReturn<CidadeModel> GetByNome(string nome);
        IReturn Post(CidadeModel cliente);
        IReturn Put(int codigo, CidadeModel cliente);
        IReturn Delete(int codigo);
    }
}
