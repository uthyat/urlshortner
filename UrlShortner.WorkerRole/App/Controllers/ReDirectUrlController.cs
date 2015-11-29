using System;
using System.Net;
using System.Web.Http;
using UrlShortner.WorkerRole.App.Store;

namespace UrlShortner.WorkerRole.App.Controllers
{
    public class RedirectUrlController : ApiController
    {
        [HttpGet]
        public IHttpActionResult RedirectUrl(string hashId)
        {
            string url;
            bool found = UrlStore.Instance.Dictionary.TryGetValue(hashId, out url);

            if (!found)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Redirect(new UriBuilder(url).Uri);
        }
    }
}
