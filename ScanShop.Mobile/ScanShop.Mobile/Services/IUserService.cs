using ScanShop.Shared.Dto.User;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace ScanShop.Mobile.Services
{
    public interface IUserService
    {
        Task SaveCurrentUserAsync(JwtSecurityToken jwtToken);
        Task<UserDto> GetCurrentUserAsync();
    }
}