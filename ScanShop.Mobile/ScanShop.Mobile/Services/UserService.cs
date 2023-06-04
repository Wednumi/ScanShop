using ScanShop.Mobile.Services;
using ScanShop.Shared.Dto;
using ScanShop.Shared.Dto.User;
using System;
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
            var userId = jwtToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            await SecureStorage.SetAsync("UserId", userId);

            var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (!string.IsNullOrEmpty(role))
            {
                await SecureStorage.SetAsync("Role", role);
            }
        }

        public async Task<UserDto> GetCurrentUserAsync()
        {
            var getUserInfoQuery = new GetUserInfoQueryDto
            {
                UserId = Guid.Parse(await SecureStorage.GetAsync("UserId"))
            };
            var httpClientService = DependencyService.Get<IHttpClientService>();
            var endpoint = "api/User/info";
            var response = await httpClientService.PostAsync(endpoint, getUserInfoQuery);
            return await httpClientService.ReadResponseAsync<UserDto>(response);
        }
    }
}