using System.Collections.Concurrent;
using System.Web.Http;
using UrlShortner.WorkerRole.App.Utility;

namespace UrlShortner.WorkerRole.App.Controllers
{
    public class UrlController : ApiController
    {
        private readonly static ConcurrentDictionary<string, string> Dictionary = 
            new ConcurrentDictionary<string, string>();

        public IHttpActionResult GetUrl(string id)
        {
            string urlHash = ComputeHash.GetHashString(id);

            bool isAdded = Dictionary.TryAdd(urlHash, id);

            return Ok(urlHash);
        }

    }
}
