namespace ScanShop.Db.Entities
{
    public class ShopUser : BaseEntity
    {
        public float Discount { get; set; }
        public float Bonuses { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IList<Product> Saved { get; set; }
        public IList<Product> Cart { get; set; }
        public IList<Order> Orders { get; set; }
        public IList<Message> Messages { get; set; }
        public IList<Review> Reviews { get; set; }
    }
}
