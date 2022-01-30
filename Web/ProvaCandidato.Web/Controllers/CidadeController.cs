using ProvaCandidato.Application.ApiProvaCandidato;
using ProvaCandidato.Application.ApiProvaCandidato.Cidade.Models;
using System.Web.Mvc;

namespace ProvaCandidato.Web.Controllers
{
    [RoutePrefix("Cidade")]
    public class CidadeController : WebController
    {
        public CidadeController()
        {
        }

        // Views

        [HttpGet, Route(""), Route("Index")]
        public ActionResult Index()
        {
            var response = ApiProvaCandidato.Cidade.GetAll();

            return View("Index", response);
        }

        [HttpGet, Route("Cadastrar")]
        public ActionResult Cadastrar()
        {
            return PartialView("_Cadastrar");
        }

        [HttpGet, Route("Alterar/{codigo}")]
        public ActionResult Alterar(int codigo)
        {
            if (codigo == default || codigo < 1)
            {
                return Warning("Por favor informe um código de cidade válido");
            }

            var response = ApiProvaCandidato.Cidade.GetByCodigo(codigo);

            if (!response.IsSuccess)
            {
                return Danger(response.Message);
            }

            return PartialView("_Alterar", response.Content);
        }

        // Actions

        [HttpPost, Route("Post")]
        public ActionResult Post(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return Warning("Por favor informe o nome da cidade");
            }

            if (nome.Trim().Length < 3)
            {
                return Warning("Por favor informe o nome da cidade com mais de 3 caracteres");
            }

            if (nome.Trim().Length > 50)
            {
                return Warning("Por favor informe o nome da cidade com menos de 50 caracteres");
            }

            var response = ApiProvaCandidato.Cidade.Post(new CidadeModel()
            {
                Nome = nome,
            });

            if (!response.IsSuccess)
            {
                return Danger(response.Message);
            }

            return Index();
        }

        [HttpPost, Route("Put")]
        public ActionResult Put(CidadeModel cidade)
        {
            if (cidade.Codigo == default || cidade.Codigo < 1)
            {
                return Warning("Por favor informe um código de cidade válido");
            }

            if (string.IsNullOrEmpty(cidade.Nome))
            {
                return Warning("Por favor informe o nome da cidade");
            }

            if (cidade.Nome.Trim().Length < 3)
            {
                return Warning("Por favor informe o nome da cidade com mais de 3 caracteres");
            }

            if (cidade.Nome.Trim().Length > 50)
            {
                return Warning("Por favor informe o nome da cidade com menos de 50 caracteres");
            }

            var response = ApiProvaCandidato.Cidade.Put(cidade);

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
                return Warning("Por favor informe um código de cidade válido");
            }

            var response = ApiProvaCandidato.Cidade.Delete(codigo);

            if (!response.IsSuccess)
            {
                return Danger(response.Message);
            }

            return Index();
        }
    }
}
