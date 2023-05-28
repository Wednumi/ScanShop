namespace ScanShop.Shared.Result.Errors
{
    public class MappingError : IError
    {
        public string Message { get; set; } = "Error of mapping entity";
    }
}
