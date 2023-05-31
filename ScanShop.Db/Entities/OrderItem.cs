namespace ScanShop.Db.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public float Amount { get; set; }

        //properties so ef core can create many to many relation
        public IList<ShopUser> Users { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
