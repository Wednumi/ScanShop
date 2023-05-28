using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ScanShop.Mobile.Services;
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

        public async Task<string> ReadResponseAsync<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(responseContent);
            return jwtToken.RawData;
        }
    }
}