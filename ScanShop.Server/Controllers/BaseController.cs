using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScanShop.Db.DbContext;
using ScanShop.Db.Entities;
using ScanShop.Shared.Result;
using System.Security.Claims;

namespace ScanShop.Server.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public BaseController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected ActionResult FromFeatureResult(FeatureResult result)
        {
            if (result.Success)
            {
                return Ok();
            }
            if (result.UserErrors is not null && result.UserErrors.Any())
            {
                return BadRequest(result.UserErrors);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ServerErrors);
        }
        protected ActionResult FromFeatureResult<T>(FeatureResult<T> result) where T : class
        {
            if (result.Success)
            {
                return Ok(result.Result);
            }
            if (result.UserErrors is not null && result.UserErrors.Any())
            {
                return BadRequest(result.UserErrors);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ServerErrors);
        }

        protected IQueryable<ShopUser> GetUserQuery()
        {
            return _context.ShopUsers.Where(u => u.Id == GetUserId());
        }

        protected Guid GetUserId()
        {
            var idClaim = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First();
            return Guid.Parse(idClaim.Value);            
        }
    }
}
