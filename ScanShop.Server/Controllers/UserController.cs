using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScanShop.Db.DbContext;
using ScanShop.Shared.Dto;

namespace ScanShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, ApplicationDbContext context,
            IMapper mapper)
            : base(context, mapper)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("info")]
        public async Task<ActionResult<UserDto>> GetInfo()
        {
            var userId = GetUserId();
            var shopUser = await _context.ShopUsers.FirstOrDefaultAsync(u => u.Id == userId);

            var identity = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId.ToString());

            var userDto = new UserDto();

            _mapper.Map(shopUser, userDto);
            _mapper.Map(identity, userDto);

            return userDto;
        }
    }
}
