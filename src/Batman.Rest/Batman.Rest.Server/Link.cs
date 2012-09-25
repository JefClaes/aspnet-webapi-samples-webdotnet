using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batman.Rest.Server
{
    public class Link
    {
        public string Rel { get; set; }

        public Uri Href { get; set; }
    }
}
