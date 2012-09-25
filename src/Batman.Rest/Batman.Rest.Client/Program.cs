using System;
using System.Net.Http;
using Batman.Rest.Server;

namespace Batman.Rest.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080")
            };

            client.PostAsJsonAsync("api/batresource", new BatResource("3", "Keys to the Tumbler", 1))
                .ContinueWith(res => res.Result.EnsureSuccessStatusCode());

            Console.WriteLine("Continue..");
            Console.ReadLine();

            client.GetAsync("api/batresource/3")
                .ContinueWith(res =>
                {
                    var desc = res.Result.Content.ReadAsAsync<BatResource>().Result.Description;
                    Console.WriteLine(desc);
                });

            Console.ReadLine();
        }
    }
}
