﻿using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScanShop.Mobile.Services
{
    public interface IHttpClientService
    {
        bool IsAuthenticated { get; }
        Task InitializeAsync();
        Task SetBearerTokenAsync(JwtSecurityToken jwtToken);
        Task<T> GetFromJsonAsync<T>(string endpoint, string query = null);
        Task<HttpResponseMessage> PostAsync<T>(string endpoint, T payload = default);
        Task<HttpResponseMessage> PutAsync(string endpoint, string query);
        Task<T> ReadResponseAsync<T>(HttpResponseMessage response);
    }
}