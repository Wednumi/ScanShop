namespace ScanShop.Shared.Result.Errors
{
    public class AddAdminError : IError
    {
        public string Message { get; set; } = "Error when adding admin role to user";
    }
}
