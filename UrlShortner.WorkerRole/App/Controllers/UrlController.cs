using System.Web.Http;
using UrlShortner.WorkerRole.App.Store;
using UrlShortner.WorkerRole.App.Utility;

namespace UrlShortner.WorkerRole.App.Controllers
{
    public class UrlController : ApiController
    {
        public IHttpActionResult Post([FromBody]string url)
        {
            string urlHash = ComputeHash.GetHashString(url);

            bool isAdded = UrlStore.Instance.Dictionary.TryAdd(urlHash, url);

            return Ok(HostResolver.GetShortUrl(urlHash));
        }
    }
}
