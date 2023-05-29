using System;
using System.Threading.Tasks;

namespace ScanShop.Mobile.Services
{
    public interface IConfigurationService
    {
        Task<Uri> GetBaseUrlAsync();
    }
}