using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScanShop.Db.DbContext;
using ScanShop.Db.Entities;
using ScanShop.Shared.Dto.Account;
using ScanShop.Shared.Result;
using ScanShop.Shared.Result.Errors;

namespace ScanShop.Server.Features.Account
{
    public class CreateShopUserCommand : IRequest<FeatureResult>
    {
        public ShopUser User { get; set; }

        public CreateShopUserCommand(ShopUser user)
        {
            User = user;
        }

        public class CreateShopUserCommandHandler
            : IRequestHandler<CreateShopUserCommand, FeatureResult>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly ILogger<SignUpCommand> _logger;

            public CreateShopUserCommandHandler(
                ApplicationDbContext dbContext,
                ILogger<SignUpCommand> logger)
            {
                _dbContext = dbContext;
                _logger = logger;
            }

            public async Task<FeatureResult> Handle(CreateShopUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    await _dbContext.ShopUsers.AddAsync(request.User);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                    return FeatureResult.FromServerError(new CreateUserError());
                }
                return new FeatureResult();
            }
        }
    }
}
