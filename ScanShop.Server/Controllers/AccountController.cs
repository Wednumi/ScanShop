using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult<FeatureResult>> SignUp(SignUpCommand signUp)
        {
            var result = await _mediator.Send(signUp);
            return FromFeatureResult(result);
        }

        [HttpPost("sign-in")]
        public async Task SignIn()
        {
            throw new NotImplementedException();
        }
    }
}
