namespace ScanShop.Db.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public IList<Product> Products { get; set; }
    }
}
