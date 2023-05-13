using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScanShop.Shared.Dto.Account;

namespace ScanShop.Server.Features.Account
{
    public class SignUpCommand : SignUpCommandDto, IRequest<ActionResult<SignUpResponse>>
    {
        public class SignUpCommandHandler
            : IRequestHandler<SignUpCommand, ActionResult<SignUpResponse>>
        {
            public async Task<ActionResult<SignUpResponse>> Handle(SignUpCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
