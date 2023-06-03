namespace ScanShop.Db.Entities
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public ShopUser? User { get; set; }
    }
}
