using Microsoft.AspNetCore.Identity;

namespace ScanShop.Server.Services.Interfaces
{
    public interface IJwtGenerator
    {
        public Task<string> GenerateAsync(IdentityUser user);
    }
}
