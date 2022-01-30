using System.Web.Mvc;

namespace ProvaCandidato.Web.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [HttpGet, Route(""), Route("Home")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
