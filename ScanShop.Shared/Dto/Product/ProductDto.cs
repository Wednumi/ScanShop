using System;

namespace ScanShop.Shared.Dto.Product
{
    public class ProductDto
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Amount { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
