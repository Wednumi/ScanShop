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
                .Where(o => o.CheckoutTime == null)
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ToListAsync();

            var dto = _mapper.Map<List<Order>, List<OrderDto>>(orders);

            return Ok(dto);
        }

        [Authorize(Roles ="admin")]
        [HttpGet("all")]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ToListAsync();

            var dto = _mapper.Map<List<Order>, List<OrderDto>>(orders);

            return Ok(dto);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("all-without-checkout")]
        public async Task<ActionResult<List<OrderDto>>> GetAllWithoutCheckoutOrders()
        {
            var orders = await _context.Orders
                .Where(o => o.CheckoutTime == null)
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ToListAsync();

            var dto = _mapper.Map<List<Order>, List<OrderDto>>(orders);

            return Ok(dto);
        }

        [Authorize]
        [HttpGet("by-id")]
        public async Task<ActionResult<OrderDto>> OrderById(Guid id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if(order is null)
            {
                return BadRequest("Does not exist");
            }

            var dto = _mapper.Map<OrderDto>(order);

            return Ok(dto);
        }

        [Authorize(Roles ="admin")]
        [HttpPut("pack")]
        public async Task<ActionResult<DateTime>> PackOrder(Guid id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order is null)
            {
                return BadRequest("Does not exist");
            }

            var time = DateTime.UtcNow;
            order.PackedTime = time;

            await _context.SaveChangesAsync();

            return Ok(time);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("checkout")]
        public async Task<ActionResult<DateTime>> CheckoutOrder(Guid id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order is null)
            {
                return BadRequest("Does not exist");
            }

            var time = DateTime.UtcNow;
            order.CheckoutTime = time;

            await _context.SaveChangesAsync();

            return Ok(time);
        }
    }
}
