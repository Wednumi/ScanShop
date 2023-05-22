namespace ScanShop.Shared.Result.Errors
{
    public class CreateUserError : IError
    {
        public string Message { get; set; } = "Error when creating the user";
    }
}
