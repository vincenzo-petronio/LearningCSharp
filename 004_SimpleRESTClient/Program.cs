using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace _004_SimpleRESTClient
{
    /// <summary>
    /// Chiamata ad API Rest con serializzazione.
    /// </summary>
    class Program
    {
        private static readonly HttpClient mHttpClient = new HttpClient();

        static void Main(string[] args)
        {
            GetApiData().Wait();

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        private static async Task GetApiData()
        {
            var dataStringJson = await mHttpClient.GetStringAsync("http://jsonplaceholder.typicode.com/posts");
            Console.WriteLine(dataStringJson);
            Console.Write(Environment.NewLine);

            var serializer = new DataContractJsonSerializer(typeof(List<Post>));
            var dataStreamJson = await mHttpClient.GetStreamAsync("http://jsonplaceholder.typicode.com/posts");
            List<Post> posts = serializer.ReadObject(dataStreamJson) as List<Post>;
            foreach (Post p in posts)
            {
                Console.WriteLine(p.Id + " " + p.Title);
            }
        }
    }
}
