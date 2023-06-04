using ScanShop.Mobile.Services;
using System.IdentityModel.Tokens.Jwt;
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

        public HttpClientService()
        {
            _httpClient = new HttpClient();
            var configurationService = DependencyService.Get<IConfigurationService>();
            _httpClient.BaseAddress = configurationService.GetBaseUrlAsync().Result;
        }

        public bool IsAuthenticated { get; private set; }

        public async Task InitializeAsync()
        {
            var bearerToken = await SecureStorage.GetAsync("BearerToken");
            IsAuthenticated = !string.IsNullOrEmpty(bearerToken);
            if (IsAuthenticated)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }
        }

        public async Task SetBearerTokenAsync(JwtSecurityToken jwtToken)
        {
            var bearerToken = jwtToken.RawData;
            await SecureStorage.SetAsync("BearerToken", bearerToken);
        }

        public async Task<T> GetFromJsonAsync<T>(string endpoint, string query = null)
        {
            return await _httpClient.GetFromJsonAsync<T>(endpoint + "?" + query);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T payload = default)
        {
            return await _httpClient.PostAsJsonAsync(endpoint, payload);
        }

        public async Task<HttpResponseMessage> PutAsync(string endpoint, string query)
        {
            return await _httpClient.PutAsync(endpoint + "?" + query, null);
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