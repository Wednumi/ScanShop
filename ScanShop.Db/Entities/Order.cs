namespace ScanShop.Db.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public ShopUser? User { get; set; }
        public IList<Product> Product { get; set; }
        public DateTime? PackedTime { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? PaidTime { get; set; }
    }
}
