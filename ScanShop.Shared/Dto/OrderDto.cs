using System.Collections.Generic;
using System;

namespace ScanShop.Shared.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CustomerFullName { get; set; }
        public IList<OrderItemDto> OrderItems { get; set; }
        public DateTime? PackedTime { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? PaidTime { get; set; }
        public DateTime? CheckoutTime { get; set; }
    }
}
