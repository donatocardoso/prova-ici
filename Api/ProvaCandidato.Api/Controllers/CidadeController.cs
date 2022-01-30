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

        [HttpGet, Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var cidades = _cidadeService.GetAll();

            if (!cidades.IsSuccess)
            {
                return BadRequest(cidades);
            }

            return Ok(cidades);
        }

        [HttpGet, Route("GetByCodigo/{codigo}")]
        public IHttpActionResult GetByCodigo(int codigo)
        {
            var cidade = _cidadeService.GetByCodigo(codigo);

            if (!cidade.IsSuccess)
            {
                return BadRequest(cidade);
            }

            return Ok(cidade);
        }

        [HttpGet, Route("GetByNome/{nome}")]
        public IHttpActionResult GetByNome(string nome)
        {
            var cidade = _cidadeService.GetByNome(nome);

            if (!cidade.IsSuccess)
            {
                return BadRequest(cidade);
            }

            return Ok(cidade);
        }

        [HttpPost, Route("Post")]
        public IHttpActionResult Post([FromBody] CidadeDto cidade)
        {
            var response = _cidadeService.Post(cidade);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut, Route("Put/{codigo}")]
        public IHttpActionResult Put(int codigo, [FromBody] CidadeDto cidade)
        {
            var response = _cidadeService.Put(codigo, cidade);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete, Route("Delete/{codigo}")]
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
