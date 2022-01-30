using System.Net;
using System.Web.Http;

namespace ProvaCandidato.Api.Controllers
{
    public class BaseController : ApiController
    {
        public IHttpActionResult Forbidden<T>(T response)
        {
            return Content(HttpStatusCode.Forbidden, response);
        }

        public IHttpActionResult Unauthorized<T>(T response)
        {
            return Content(HttpStatusCode.Unauthorized, response);
        }

        public IHttpActionResult NotFound<T>(T response)
        {
            return Content(HttpStatusCode.NotFound, response);
        }

        public IHttpActionResult Created<T>(T response)
        {
            return Content(HttpStatusCode.Created, response);
        }

        public IHttpActionResult Redirect<T>(T response)
        {
            return Content(HttpStatusCode.Redirect, response);
        }

        public IHttpActionResult BadRequest<T>(T response)
        {
            return Content(HttpStatusCode.BadRequest, response);
        }

        public IHttpActionResult InternalServerError<T>(T response)
        {
            return Content(HttpStatusCode.InternalServerError, response);
        }
    }
}
