using ProvaCandidato.Domain.Cidade;
using ProvaCandidato.Domain.Cidade.Dtos;
using System.Web.Http;

namespace ProvaCandidato.Api.Controllers
{
    [RoutePrefix("Cidades")]
    public class CidadeController : BaseController
    {
        private readonly ICidadeService _cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var cidades = _cidadeService.GetAll();

            if (!cidades.IsSuccess)
            {
                return BadRequest(cidades);
            }

            return Ok(cidades);
        }

        [HttpGet]
        public IHttpActionResult GetByCodigo(int codigo)
        {
            var cidade = _cidadeService.GetByCodigo(codigo);

            if (!cidade.IsSuccess)
            {
                return BadRequest(cidade);
            }

            return Ok(cidade);
        }

        [HttpGet]
        public IHttpActionResult GetByNome(string nome)
        {
            var cidade = _cidadeService.GetByNome(nome);

            if (!cidade.IsSuccess)
            {
                return BadRequest(cidade);
            }

            return Ok(cidade);
        }

        [HttpPost]
        public IHttpActionResult Post(string nome)
        {
            var response = _cidadeService.Post(nome);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public IHttpActionResult Put(int codigo, CidadeDto cidade)
        {
            var response = _cidadeService.Put(codigo, cidade);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int codigo)
        {
            var response = _cidadeService.Delete(codigo);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
