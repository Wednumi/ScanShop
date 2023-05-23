namespace ScanShop.Shared.Result.Errors
{
    public class WrongPasswordError : IError
    {
        public string Message { get; set; } = "Wrong login password";
    }
}
