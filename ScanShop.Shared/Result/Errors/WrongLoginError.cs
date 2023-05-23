namespace ScanShop.Shared.Result.Errors
{
    public class WrongLoginError : IError
    {
        public string Message { get; set; } = "Wrong login email";
    }
}
