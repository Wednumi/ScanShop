using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScanShop.Db.DbContext;
using ScanShop.Db.Entities;
using ScanShop.Shared.Dto.Account;
using ScanShop.Shared.Extensions;
using ScanShop.Shared.Result;
using ScanShop.Shared.Result.Errors;

namespace ScanShop.Server.Features.Account
{
    public class SignUpCommand : SignUpCommandDto, IRequest<FeatureResult>
    {
        public class SignUpCommandHandler
            : IRequestHandler<SignUpCommand, FeatureResult>
        {
            private readonly UserManager<IdentityUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly ApplicationDbContext _dbContext;
            private readonly ILogger<SignUpCommand> _logger;
            private readonly IMediator _mediator;

            public SignUpCommandHandler(UserManager<IdentityUser> userManager,
                RoleManager<IdentityRole> roleManager,
                ApplicationDbContext dbContext,
                ILogger<SignUpCommand> logger,
                IMediator mediator)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _dbContext = dbContext;
                _logger = logger;
                _mediator = mediator;
            }

            public async Task<FeatureResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
            {
                var identityUser = new IdentityUser()
                {
                    Email = request.Email,
                    UserName = request.Email
                };

                var identityResult = await _userManager.CreateAsync(identityUser, request.Password);
                if (identityResult.Succeeded is false) 
                {
                    return identityResult.ToFeatureResult();
                }

                var addAdminReslut = await AddAdminIfFirst(identityUser);
                if(addAdminReslut.Success is false)
                {
                    return addAdminReslut;
                }

                var shopUser = new ShopUser()
                {
                    Id = Guid.Parse(identityUser.Id),
                    Name = request.Name,
                    LastName = request.LastName
                };
                var createUserResult = await _mediator.Send(new CreateShopUserCommand(shopUser), cancellationToken);
                if(createUserResult.Success is false)
                {
                    await _userManager.DeleteAsync(identityUser);                    
                }
                return createUserResult;
            }

            private async Task<FeatureResult> AddAdminIfFirst(IdentityUser user)
            {
                var isFirst = !await _userManager.Users.AnyAsync(u => u.Id != user.Id);
                if(isFirst)
                {
                    try
                    {
                        var adminRoleName = "admin";
                        await _roleManager.CreateAsync(new IdentityRole(adminRoleName));
                        await _userManager.AddToRoleAsync(user, adminRoleName);
                    }
                    catch(Exception ex)
                    {
                        _logger.LogError(ex.Message, ex);
                        return new FeatureResult(serverErrors: new() { new AddAdminError() });
                    }
                }
                return new FeatureResult();
            }
        }
    }
}
