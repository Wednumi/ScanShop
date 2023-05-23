using MediatR;
using Microsoft.AspNetCore.Identity;
using ScanShop.Db.DbContext;
using ScanShop.Server.Services.Interfaces;
using ScanShop.Shared.Dto.Account;
using ScanShop.Shared.Result;
using ScanShop.Shared.Result.Errors;

namespace ScanShop.Server.Features.Account
{
    public class SignInCommand : SignInCommandDto, IRequest<FeatureResult<string>>
    {
        public class SignInCommandHandler
            : IRequestHandler<SignInCommand, FeatureResult<string>>
        {
            private readonly UserManager<IdentityUser> _userManager;
            private readonly ApplicationDbContext _dbContext;
            private readonly ILogger<SignInCommand> _logger;
            private readonly IJwtGenerator _jwtGenerator;

            public SignInCommandHandler(
                UserManager<IdentityUser> userManager,
                ApplicationDbContext dbContext,
                ILogger<SignInCommand> logger,
                IJwtGenerator jwtGenerator)
            {
                _userManager = userManager;
                _dbContext = dbContext;
                _logger = logger;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<FeatureResult<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
            {
                var userResult = await UserFromCredentials(request);
                if(userResult.Success is false)
                {
                    return new FeatureResult<string>(userResult);
                }

                var token = await _jwtGenerator.GenerateAsync(userResult.Result);
                return new FeatureResult<string>(token);
            }

            private async Task<FeatureResult<IdentityUser>> UserFromCredentials(SignInCommand request)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if(user is null)
                {
                    return FeatureResult.FromUserError<IdentityUser>(new WrongLoginError());
                }

                var validUser = await _userManager.CheckPasswordAsync(user, request.Password);
                if(validUser is false) 
                {
                    return FeatureResult.FromUserError<IdentityUser>(new WrongPasswordError());
                }

                return new FeatureResult<IdentityUser>(user);
            }
        }
    }
}
