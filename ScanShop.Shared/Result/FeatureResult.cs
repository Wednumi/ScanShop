using ScanShop.Shared.Result.Errors;
using System.Collections.Generic;

namespace ScanShop.Shared.Result
{
    public class FeatureResult
    {
        public bool Success { get; set; }
        public List<IError> UserErrors { get; set; }
        public List<IError> ServerErrors { get; set; }

        public FeatureResult()
        {
            Success = true;
        }

        public FeatureResult(List<IError> userErrors = null, List<IError> serverErrors = null)
        {
            Success = false;
            ServerErrors = serverErrors;
            UserErrors = userErrors;
        }

        public static FeatureResult FromUserError(IError error)
        {
            return new FeatureResult(userErrors: new List<IError>() { error });
        }

        public static FeatureResult FromServerError(IError error)
        {
            return new FeatureResult(serverErrors: new List<IError>() { error });
        }

        public static FeatureResult<T> FromUserError<T>(IError error) where T : class
        {
            return new FeatureResult<T>(userErrors: new List<IError>() { error });
        }

        public static FeatureResult<T> FromServerError<T>(IError error) where T : class
        {
            return new FeatureResult<T>(serverErrors: new List<IError>() { error });
        }
    }

    public class FeatureResult<T> : FeatureResult where T : class
    {
        public T Result { get; set; }

        public FeatureResult(T result)
        {
            Success = true;
            Result = result;
        }

        public FeatureResult(List<IError> userErrors = null, List<IError> serverErrors = null)
            :base(userErrors, serverErrors) { }

        public FeatureResult(FeatureResult featureResult)
            :base(featureResult.UserErrors, featureResult.ServerErrors)
        { }
    }
}
