using Client.Models;
using System.Net.Http.Json;
namespace Client.Services
{
    public class HttpService : HttpClient
    {
        static Uri _baseAddress = new Uri("https://localhost:44346/"); // this is a local address for debugging, needs to be set to the correct URI for production
        static HttpClient _client;

        static HttpService()
        {
            _client = new HttpClient();
            _client.BaseAddress = _baseAddress;
        }

        internal static Task<HttpResponseMessage> PostAsync(string route, object content)
        {
            return _client.PostAsJsonAsync(route, content);
        }
        internal static Task<EncFile?> GetFileAsync(string route)
        {
            return _client.GetFromJsonAsync<EncFile>("api/FileDownload/id?id=42030a2a-11d1-4b8a-9b7f-84fc821db3e4");
        }
    }
}
