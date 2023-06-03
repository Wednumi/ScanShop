using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScanShop.Db.DbContext;
using ScanShop.Shared.Dto.User;
using ScanShop.Shared.Result;
using ScanShop.Shared.Result.Errors;

namespace ScanShop.Server.Features.User
{
    public class GetUserInfoQuery : GetUserInfoQueryDto, IRequest<FeatureResult<UserDto>>
    {
        public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, FeatureResult<UserDto>>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetUserInfoQueryHandler(ApplicationDbContext dbContext,
                IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<FeatureResult<UserDto>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
            {
                var shopUser = await _dbContext.ShopUsers.FirstOrDefaultAsync(u => u.Id == request.UserId,
                    cancellationToken);
                if(shopUser is null)
                {
                    return FeatureResult.FromUserError<UserDto>(new EntityDoesNotExistError());
                }

                var identity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId.ToString(), 
                    cancellationToken);
                if (identity is null)
                {
                    return FeatureResult.FromUserError<UserDto>(new EntityDoesNotExistError());
                }

                var userDto = new UserDto();
                try
                {
                    _mapper.Map(shopUser, userDto);
                    _mapper.Map(identity, userDto);
                }
                catch
                {
                    return FeatureResult.FromUserError<UserDto>(new MappingError());
                }

                return new FeatureResult<UserDto> (userDto);
            }
        }
    }
}
