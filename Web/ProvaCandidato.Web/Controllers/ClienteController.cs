using ProvaCandidato.Application.ApiProvaCandidato;
using ProvaCandidato.Application.ApiProvaCandidato.Cliente.Models;
using ProvaCandidato.Web.ViewModels.Cliente;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ProvaCandidato.Web.Controllers
{
    [RoutePrefix("Cliente")]
    public class ClienteController : WebController
    {
        public ClienteController()
        {
        }

        // Views

        [HttpGet, Route(""), Route("Index")]
        public ActionResult Index()
        {
            var response = ApiProvaCandidato.Cliente.GetAll();

            return View("Index", response);
        }

        [HttpGet, Route("Cadastrar")]
        public ActionResult Cadastrar()
        {
            var cidades = ApiProvaCandidato.Cidade.GetAll();

            if (!cidades.IsSuccess)
            {
                return Danger("Não foi possível buscar as cidades");
            }

            if (!cidades.Content.Any())
            {
                return Warning("Nenhuma cidade cadastrada");
            }

            return PartialView("_Cadastrar", cidades);
        }

        [HttpGet, Route("Alterar/{codigo}")]
        public ActionResult Alterar(int codigo)
        {
            if (codigo == default || codigo < 1)
            {
                return Warning("Por favor informe um código de cliente válido");
            }

            var cidades = ApiProvaCandidato.Cidade.GetAll();

            if (!cidades.IsSuccess)
            {
                return Danger("Não foi possível buscar as cidades");
            }

            if (!cidades.Content.Any())
            {
                return Warning("Nenhuma cidade cadastrada");
            }

            var cliente = ApiProvaCandidato.Cliente.GetByCodigo(codigo);

            if (!cliente.IsSuccess)
            {
                return Danger(cliente.Message);
            }

            return PartialView("_Alterar", new ClienteAlterarViewModel()
            {
                Cidades = cidades.Content,
                Cliente = cliente.Content,
            });
        }

        // Actions

        [HttpPost, Route("Post")]
        public ActionResult Post(ClienteModel cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                return Warning("Por favor informe o nome da cidade");
            }

            if (cliente.Nome.Trim().Length < 3)
            {
                return Warning("Por favor informe o nome da cidade com mais de 3 caracteres");
            }

            if (cliente.Nome.Trim().Length > 50)
            {
                return Warning("Por favor informe o nome da cidade com menos de 50 caracteres");
            }

            if (cliente.DataNascimento < DateTime.Parse("01-01-1900"))
            {
                return Warning("Por favor informe uma data de nascimento maior que 01-01-1900");
            }

            if (cliente.DataNascimento > DateTime.Now)
            {
                return Warning($"Por favor informe uma data de nascimento menor que {DateTime.Now:dd-mm-yyyy}");
            }

            if (cliente.CidadeId == default || cliente.CidadeId < 1)
            {
                return Warning("Por favor informe um código de cidade válido");
            }

            var response = ApiProvaCandidato.Cliente.Post(cliente);

            if (!response.IsSuccess)
            {
                return Danger(response.Message);
            }

            return Index();
        }

        [HttpPost, Route("Put")]
        public ActionResult Put(ClienteModel cliente)
        {
            if (cliente.Codigo == default || cliente.Codigo < 1)
            {
                return Warning("Por favor informe um código de cliente válido");
            }

            if (string.IsNullOrEmpty(cliente.Nome))
            {
                return Warning("Por favor informe o nome da cidade");
            }

            if (cliente.Nome.Trim().Length < 3)
            {
                return Warning("Por favor informe o nome da cidade com mais de 3 caracteres");
            }

            if (cliente.Nome.Trim().Length > 50)
            {
                return Warning("Por favor informe o nome da cidade com menos de 50 caracteres");
            }

            if (cliente.DataNascimento < DateTime.Parse("01-01-1900"))
            {
                return Warning("Por favor informe uma data de nascimento maior que 01-01-1900");
            }

            if (cliente.DataNascimento > DateTime.Now)
            {
                return Warning($"Por favor informe uma data de nascimento menor que {DateTime.Now:dd-mm-yyyy}");
            }

            if (cliente.CidadeId == default || cliente.CidadeId < 1)
            {
                return Warning("Por favor informe um código de cidade válido");
            }

            var response = ApiProvaCandidato.Cliente.Put(cliente);

            if (!response.IsSuccess)
            {
                return Danger(response.Message);
            }

            return Index();
        }

        [HttpPost, Route("Delete")]
        public ActionResult Delete(int codigo)
        {
            if (codigo == default || codigo < 1)
            {
                return Warning("Por favor informe um código de cliente válido");
            }

            var response = ApiProvaCandidato.Cliente.Delete(codigo);

            if (!response.IsSuccess)
            {
                return Danger(response.Message);
            }

            return Index();
        }
    }
}
