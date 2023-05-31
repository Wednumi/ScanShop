using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanShop.Db.DbContext;
using ScanShop.Server.Features.Account;
using ScanShop.Shared.Dto.Account;
using ScanShop.Shared.Result;

namespace ScanShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator, ApplicationDbContext context,
            IMapper mapper)
            : base(context, mapper) 
        {
            _mediator = mediator;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp(SignUpCommand command)
        {
            var result = await _mediator.Send(command);
            return FromFeatureResult(result);
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult> SignIn(SignInCommand command)
        {
            var result = await _mediator.Send(command);
            return FromFeatureResult(result);
        }
    }
}
