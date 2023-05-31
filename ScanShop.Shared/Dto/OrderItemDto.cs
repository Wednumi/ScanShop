using System;

namespace ScanShop.Shared.Dto
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public float Amount { get; set; }
    }
}
