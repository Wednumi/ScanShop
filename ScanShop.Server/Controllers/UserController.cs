﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using ScanShop.Server.Features.User;

namespace ScanShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("info")]
        public async Task<ActionResult> GetInfo(GetUserInfoQuery command)
        {
            var result = await _mediator.Send(command);
            return FromFeatureResult(result);
        }
    }
}