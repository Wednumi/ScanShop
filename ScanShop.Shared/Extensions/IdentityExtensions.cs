using Microsoft.AspNetCore.Identity;
using ScanShop.Shared.Result;
using ScanShop.Shared.Result.Errors;
using System.Collections.Generic;
using System.Linq;

namespace ScanShop.Shared.Extensions
{
    public static class IdentityExtensions
    {
        public static FeatureResult ToFeatureResult(this IdentityResult identityResult)
        {
            var errors = identityResult.Errors.Select(e => (IError)new Error(e.Description));
            return new FeatureResult()
            {
                Success = errors.Any(),
                UserErrors = errors.ToList(),
            };
        }
    }
}
