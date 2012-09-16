using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.SelfHost;
using System.Web.Http;

namespace Batman.Rest.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute(
                "DefaultRoute",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            config.Formatters.Add(new BatFormatter());

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();

                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }
    }
}
