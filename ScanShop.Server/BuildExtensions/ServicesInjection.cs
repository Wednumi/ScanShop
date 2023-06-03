using ScanShop.Server.Services.Implementations;
using ScanShop.Server.Services.Interfaces;

namespace ScanShop.Server.BuildExtensions
{
    internal static class ServicesInjection
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IJwtGenerator, JwtGenerator>();
        }
    }
}
