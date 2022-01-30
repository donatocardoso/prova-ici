using ProvaCandidato.Utils.Environment;
using System.Net;
using System.Web.Mvc;

namespace ProvaCandidato.Web.Controllers
{
    public class WebController : Controller
    {
        public WebController()
        {
            ViewBag.NomeEmpresa = WebEnvironment.NomeEmpresa;
        }

        public ActionResult Success(string message)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;

            return PartialView("Success", message);
        }

        public ActionResult Info(string message)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;

            return PartialView("Info", message);
        }

        public ActionResult Warning(string message)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return PartialView("Warning", message);
        }

        public ActionResult Danger(string message)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return PartialView("Danger", message);
        }
    }
}
