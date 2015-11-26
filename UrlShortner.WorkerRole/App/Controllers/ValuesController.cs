using System.Web.Http;

namespace UrlShortner.WorkerRole.App.Controllers
{
    public class ValuesController : ApiController
    {
        public IHttpActionResult GetValues(string id)
        {
            return Ok(@"{""key1"":""value1"",""key2"":""value2""}");
        }
    }
}
