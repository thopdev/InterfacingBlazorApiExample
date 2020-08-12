using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorAPI.Client.Services
{
    public interface IHttpClientService
    {
        Task<T> GetRequestAsync<T>(string path);
        Task<TReturn> PostRequestAsync<TReturn, TModel>(string path, TModel obj);
        Task DeleteRequestAsync(string path);
    }

    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetRequestAsync<T>(string path)
        {
            var response = await _httpClient.GetAsync(path);
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<TReturn> PostRequestAsync<TReturn, TModel>(string path, TModel obj)
        {
            var response = await _httpClient.PostAsJsonAsync(path, obj);
            return await response.Content.ReadFromJsonAsync<TReturn>();
        }

        public async Task DeleteRequestAsync(string path)
        {
            var response = await _httpClient.DeleteAsync(path);
        }
    }
}
