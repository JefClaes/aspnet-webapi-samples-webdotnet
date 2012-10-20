using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace Batman.Rest.Server
{
    public class BatResourceController : ApiController
    {
        private readonly BatStore _batStore = new BatStore();

        public IEnumerable<BatResource> GetBanks()
        {
            return _batStore.GetAll();
        }

        public BatResource GetByIdentifier(string id)
        {
            var batResource = _batStore.GetById(id);

            if (batResource == null)
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.NotFound));

            // Naive implementation
            var nextId = Convert.ToInt32(id) + 1;
            var next = new Uri(Url.Link("DefaultApi", new { id = nextId }));

            batResource.Links = new List<Link>();
            batResource.Links.Add(new Link() { Href = next, Method = HttpMethod.Get, Rel = "Next" });

            return batResource;
        }

        public HttpResponseMessage Post(BatResource batResource)
        {
            _batStore.Add(batResource);

            var response = Request.CreateResponse<BatResource>(HttpStatusCode.Created, batResource);
            response.Headers.Location = new Uri(Url.Link("DefaultRoute", new { id = batResource.Id }));

            return response;
        }

        public void Put(string id, BatResource batResource)
        {
            throw new HttpResponseException(HttpStatusCode.NotImplemented);
        }

        public HttpResponseMessage Delete(string id)
        {
            _batStore.Delete(id);

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}

