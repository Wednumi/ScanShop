namespace ScanShop.Shared.Result.Errors
{
    public class Error : IError
    {
        public string Message { get; set; }

        public Error(string message)
        {
            Message = message;
        }
    }
}
