namespace ScanShop.Shared.Result.Errors
{
    public class EntityDoesNotExistError : IError
    {
        public string Message { get; set; } = "Entity with those parameters does not exist";
    }
}
