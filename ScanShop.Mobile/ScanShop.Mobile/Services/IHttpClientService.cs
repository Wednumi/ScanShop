using System.Net.Http;
using System.Threading.Tasks;

namespace ScanShop.Mobile.Services
{
    public interface IHttpClientService
    {
        Task InitializeAsync();
        bool IsAuthenticated();
        Task<HttpResponseMessage> PostAsync<T>(string endpoint, T payload);
        Task<T> ReadResponseAsync<T>(HttpResponseMessage response);
    }
}