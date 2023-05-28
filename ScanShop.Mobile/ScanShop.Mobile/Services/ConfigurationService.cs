using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ScanShop.Mobile.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConfigurationService))]

namespace ScanShop.Mobile.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public async Task<Uri> GetBaseUrlAsync()
        {
            var assembly = typeof(ConfigurationService).Assembly;
            var resourceName = "ScanShop.Mobile.Config.AppSettings.json";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("AppSettings.json file not found.");
                }

                using (var reader = new StreamReader(stream))
                {
                    var jsonString = await reader.ReadToEndAsync();
                    using (var document = JsonDocument.Parse(jsonString))
                    {
                        if (!document.RootElement.TryGetProperty("BaseUrl", out var baseUrlProperty))
                        {
                            throw new InvalidOperationException("BaseUrl not found in AppSettings.json");
                        }
                        return new Uri(baseUrlProperty.GetString());
                    }
                }
            }
        }
    }
}