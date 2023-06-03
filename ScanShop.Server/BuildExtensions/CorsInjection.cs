namespace ScanShop.Server.BuildExtensions
{
    internal static class CorsInjection
    {
        internal static string PolicyName => "policy";

        internal static void AddSetCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy(PolicyName,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }
    }
}
