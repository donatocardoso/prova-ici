using ProvaCandidato.Domain.Cidade.Dtos;
using ProvaCandidato.Utils.Commons;
using System.Collections.Generic;

namespace ProvaCandidato.Domain.Cidade
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public IReturn<IEnumerable<CidadeDto>> GetAll()
        {
            return _cidadeRepository.GetAll();
        }

        public IReturn<CidadeDto> GetByCodigo(int codigo)
        {
            return _cidadeRepository.GetByCodigo(codigo);
        }

        public IReturn<CidadeDto> GetByNome(string nome)
        {
            return _cidadeRepository.GetByNome(nome);
        }

        public IReturn<CidadeDto> Post(string nome)
        {
            return _cidadeRepository.Post(new CidadeDto()
            {
                Nome = nome,
            });
        }

        public IReturn Put(int codigo, CidadeDto cidade)
        {
            return _cidadeRepository.Put(codigo, cidade);
        }

        public IReturn Delete(int codigo)
        {
            return _cidadeRepository.Delete(codigo);
        }
    }
}
