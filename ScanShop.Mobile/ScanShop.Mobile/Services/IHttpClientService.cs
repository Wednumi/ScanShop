using System.Net.Http;
using System.Threading.Tasks;

namespace ScanShop.Mobile.Services
{
    public interface IHttpClientService
    {
        void SetBearerToken(string token);
        Task<HttpResponseMessage> PostAsync<T>(string endpoint, T payload);
        Task<string> ReadResponseAsync<T>(HttpResponseMessage response);
    }
}