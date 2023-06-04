using ScanShop.Mobile.Services;
using ScanShop.Shared.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(UserService))]

namespace ScanShop.Mobile.Services
{
    public class UserService : IUserService
    {
        public bool IsAdmin => SecureStorage.GetAsync("Role").Result == "admin";

        public async Task SaveCurrentUserAsync(JwtSecurityToken jwtToken)
        {
            var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (!string.IsNullOrEmpty(role))
            {
                await SecureStorage.SetAsync("Role", role);
            }
        }

        public async Task<UserDto> GetCurrentUserAsync()
        {
            var httpClientService = DependencyService.Get<IHttpClientService>();
            var endpoint = "api/User/info";
            var response = await httpClientService.PostAsync<string>(endpoint);
            return await httpClientService.ReadResponseAsync<UserDto>(response);
        }
    }
}