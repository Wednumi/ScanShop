namespace ScanShop.Db.Entities
{
    public class Review : BaseEntity
    {
        public Guid UserId { get; set; }
        public ShopUser? User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
    }
}
