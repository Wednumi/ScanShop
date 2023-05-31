using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScanShop.Db.DbContext;
using ScanShop.Db.Entities;
using ScanShop.Shared.Dto;

namespace ScanShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(ApplicationDbContext context,
            IMapper mapper)
            : base(context, mapper) { }

        [Authorize]
        [HttpPost("create-from-cart")]
        public async Task<ActionResult<Guid>> CreateOrderFromCart()
        {
            var user = await GetUserQuery().Include(u => u.CartItems).FirstAsync();

            var order = new Order()
            {
                UserId = GetUserId(),
                OrderItems = new List<OrderItem>(user.CartItems),
                CreatedTime = DateTime.UtcNow,
            };

            _context.Orders.Add(order);
            user.CartItems.Clear();

            await _context.SaveChangesAsync();

            return Ok(order.Id);
        }

        [Authorize]
        [HttpGet("user-orders")]
        public async Task<ActionResult<List<OrderDto>>> GetUserOrders()
        {
            var userId = GetUserId();

            var orders = await _context.Orders.Where(o => o.UserId ==  userId)
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ToListAsync();

            var dto = _mapper.Map<List<Order>, List<OrderDto>>(orders);

            return Ok(dto);
        }
    }
}
