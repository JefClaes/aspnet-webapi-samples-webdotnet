using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Http;

namespace Batman.Rest.Server
{
    public class BatFormatter : BufferedMediaTypeFormatter
    {
        public BatFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/bat"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == typeof(BatResource))
                return true;

            return false;
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            var batResource = (BatResource)value;

            using (var writer = new StreamWriter(writeStream))
            {
                writer.Write(batResource.Description + "<^..^>" + batResource.Quantity + "<^..^>");
            }
        }
    }
}
