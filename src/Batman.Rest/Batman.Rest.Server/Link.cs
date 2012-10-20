using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;

namespace Batman.Rest.Server
{
    public class Link
    {
        public string Rel { get; set; }

        public HttpMethod Method { get; set; }

        public Uri Href { get; set; }
    }
}
