using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScanShop.Db.DbContext;
using ScanShop.Db.Entities;
using ScanShop.Shared.Dto;
using System.Data;

namespace ScanShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper) { }

        [Authorize(Roles = "admin")]
        [HttpPost("update")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<CategoryDto>(category);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            var dtos = _mapper.Map<List<Category>, List<CategoryDto>>(categories);
            return Ok(dtos);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("delete")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            await _context.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();
            return Ok();
        }
    }
}
