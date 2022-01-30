using ProvaCandidato.Domain.Cliente;
using ProvaCandidato.Domain.Cliente.Dtos;
using System.Web.Http;

namespace ProvaCandidato.Api.Controllers
{
    [RoutePrefix("Clientes")]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet, Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var clientes = _clienteService.GetAll();

            if (!clientes.IsSuccess)
            {
                return BadRequest(clientes);
            }

            return Ok(clientes);
        }

        [HttpGet, Route("GetByCodigo/{codigo}")]
        public IHttpActionResult GetByCodigo(int codigo)
        {
            var cliente = _clienteService.GetByCodigo(codigo);

            if (!cliente.IsSuccess)
            {
                return BadRequest(cliente);
            }

            return Ok(cliente);
        }

        [HttpGet, Route("GetByNome/{nome}")]
        public IHttpActionResult GetByNome(string nome)
        {
            var cliente = _clienteService.GetByNome(nome);

            if (!cliente.IsSuccess)
            {
                return BadRequest(cliente);
            }

            return Ok(cliente);
        }

        [HttpPost, Route("Post")]
        public IHttpActionResult Post([FromBody] ClienteDto cliente)
        {
            var response = _clienteService.Post(cliente);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut, Route("Put/{codigo}")]
        public IHttpActionResult Put(int codigo, [FromBody] ClienteDto cliente)
        {
            var response = _clienteService.Put(codigo, cliente);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete, Route("Delete/{codigo}")]
        public IHttpActionResult Delete(int codigo)
        {
            var response = _clienteService.Delete(codigo);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
