using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScanShop.Db.DbContext;
using ScanShop.Db.Entities;
using ScanShop.Shared.Dto;

namespace ScanShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            var dtos = _mapper.Map<List<Category>, List<CategoryDto>>(categories);
            return Ok(dtos);
        }
    }
}
