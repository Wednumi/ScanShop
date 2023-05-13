using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScanShop.Server.Features.Account;
using ScanShop.Shared.Dto.Account;

namespace ScanShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult<SignUpResponse>> SignUp(SignUpCommand signUp)
        {
            return await _mediator.Send(signUp);
        }

        [HttpPost("sign-in")]
        public async Task SignIn()
        {
            throw new NotImplementedException();
        }
    }
}
