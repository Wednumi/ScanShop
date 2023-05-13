using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScanShop.Db.DbContext;

namespace ScanShop.Db
{
    public static class BuildExtension
    {
        public static void AddDbSetup(this IServiceCollection services,
            IConfiguration configuration)
        {
            var configurationString = configuration
                .GetRequiredSection("ConnectionString").Value;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configurationString, b => b.MigrationsAssembly("ScanShop.Db")));
        }
    }
}
