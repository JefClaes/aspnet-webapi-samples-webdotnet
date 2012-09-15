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

            var link = new Link() { Value = "HighestQuantity", Href = new Uri(Url.Link("DefaultApi", new { id = _batStore.GetByMostQuantity().Id })) };

            batResource.Links = new List<Link>();
            batResource.Links.Add(link);

            return batResource;
        }

        public HttpResponseMessage Post(BatResource batResource)
        {
            _batStore.AddBatResource(batResource);

            var response = Request.CreateResponse<BatResource>(HttpStatusCode.Created, batResource);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = batResource.Id }));

            return response;
        }

        public void Put(string id, BatResource batResource)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Delete(string id)
        {
            _batStore.DeleteBatResource(id);

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}

