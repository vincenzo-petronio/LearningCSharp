using BlazorWasm.Data;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWasm.Services
{
    public class JsonPlaceholderHttpClient
    {
        private readonly HttpClient httpClient;

        public JsonPlaceholderHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Photo> GetPhoto(int id)
        {
            Uri uri = new Uri($"https://jsonplaceholder.typicode.com/photos/{id}");
            return await httpClient.GetFromJsonAsync<Photo>(uri);
        }
    }
}
