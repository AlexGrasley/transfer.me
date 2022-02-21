using System.Net.Http.Json;
namespace Client.Code
{
    public class WebClient : HttpClient
    {
        static Uri _baseAddress = new Uri("https://localhost:44346/"); // this is a local address for debugging, needs to be set to the correct URI for production
        static HttpClient _client;

        static WebClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = _baseAddress;
        }

        internal static Task<HttpResponseMessage> PostAsync(string route, object content)
        {
            return _client.PostAsJsonAsync(route, content);
        }
    }
}
