using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScanShop.Mobile.Services
{
    public interface IHttpClientService
    {
        bool IsAuthenticated { get; }
        Task InitializeAsync();
        Task SetBearerTokenAsync(JwtSecurityToken jwtToken);
        Task<HttpResponseMessage> GetAsync(string endpoint);
        Task<HttpResponseMessage> PostAsync<T>(string endpoint, T payload);
        Task<T> ReadResponseAsync<T>(HttpResponseMessage response);
    }
}