using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScanShop.Db.DbContext;
using ScanShop.Db.Entities;
using ScanShop.Shared.Dto.Product;
using System.Data;

namespace ScanShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(ApplicationDbContext context, IMapper mapper)
           : base(context, mapper) { }

        [HttpGet("all")]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            var dto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return Ok(dto);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("update")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("delete")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            await _context.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
            return Ok();
        }
    }
}
