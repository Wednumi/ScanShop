using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScanShop.Db.DbContext;
using ScanShop.Db.Entities;
using ScanShop.Shared.Dto.OrderItem;
using ScanShop.Shared.Dto.Product;

namespace ScanShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseController
    {
        public CartController(ApplicationDbContext context,
            IMapper mapper)
            : base(context, mapper) { }

        [Authorize]
        [HttpPost("add-to-cart")]
        public async Task<ActionResult> AddProductToCart(OrderItemDto orderItem)
        {
            var user = await GetUserQuery().Include(u => u.CartItems).FirstAsync();          

            var existed = GetExisted(user.CartItems, orderItem);
            if (existed is not null)
            {
                existed.Amount += orderItem.Amount;
            }
            else
            {
                var mapped = _mapper.Map<OrderItem>(orderItem);
                user.CartItems.Add(mapped);
            }            

            await _context.SaveChangesAsync();

            return Ok();
        }

        private static OrderItem? GetExisted(IList<OrderItem> list, OrderItemDto item)
        {
            return list.Where(i => i.ProductId == item.ProductId).FirstOrDefault();
        }

        [Authorize]
        [HttpPut("update-amount")]
        public async Task<ActionResult> UpdateAmount(OrderItemDto orderItem)
        {
            if (orderItem.Amount == 0)
            {
                await RemoveFromCartOrdetItem(orderItem);
                return Ok();
            }

            var user = await GetUserQuery().Include(u => u.CartItems).FirstAsync();

            var existed = GetExisted(user.CartItems, orderItem);
            if(existed is null)
            {
                return BadRequest("Entity does not exist");
            }

            existed.Amount = orderItem.Amount;
            _context.OrderItems.Update(existed);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpPost("remove")]
        public async Task<ActionResult> RemoveFromCartOrdetItem(OrderItemDto orderItem)
        {
            var user = await GetUserQuery().Include(u => u.CartItems).FirstAsync();

            var existed = GetExisted(user.CartItems, orderItem);
            if (existed is null)
            {
                return BadRequest("Entity does not exist");
            }

            user.CartItems.Remove(existed);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpGet("get-cart")]
        public async Task<ActionResult<List<ProductDto>>> GetUserCart()
        {
            var cartItems = await GetUserQuery()
                .Include(u => u.CartItems)
                .Select(u => u.CartItems)
                .FirstAsync();

            var dto = _mapper.Map<IList<OrderItem>, IList<OrderItemDto>>(cartItems);

            return Ok(dto);
        }
    }
}
