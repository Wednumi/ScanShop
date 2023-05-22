namespace ScanShop.Db.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Amount { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public IList<ShopUser> UsersSaved { get; set; }
        public IList<ShopUser> UsersPlacedInCart { get; set; }
    }
}
