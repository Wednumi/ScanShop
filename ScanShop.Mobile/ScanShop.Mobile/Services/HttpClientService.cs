using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ScanShop.Mobile.Services;
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

        public void SetBearerToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T payload)
        {
            var jsonPayload = JsonSerializer.Serialize(payload);
            HttpContent httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(endpoint, httpContent);
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