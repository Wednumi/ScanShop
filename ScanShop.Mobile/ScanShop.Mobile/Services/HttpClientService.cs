using ScanShop.Mobile.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(HttpClientService))]

namespace ScanShop.Mobile.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private bool _isAuthenticated;

        public HttpClientService()
        {
            _httpClient = new HttpClient();
            var configurationService = DependencyService.Get<IConfigurationService>();
            _httpClient.BaseAddress = configurationService.GetBaseUrlAsync().Result;
        }

        public async Task InitializeAsync()
        {
            var bearerToken = await SecureStorage.GetAsync("BearerToken");
            _isAuthenticated = !string.IsNullOrEmpty(bearerToken);
            if (_isAuthenticated)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }
        }

        public bool IsAuthenticated()
        {
            return _isAuthenticated;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T payload)
        {
            return await _httpClient.PostAsJsonAsync(endpoint, payload);
        }

        public async Task<T> ReadResponseAsync<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            if (typeof(T) == typeof(string))
            {
                return (T)(object)await response.Content.ReadAsStringAsync();
            }
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}