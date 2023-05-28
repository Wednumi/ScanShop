using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ScanShop.Db.Entities;
using ScanShop.Shared.Dto.User;

namespace ContextStudier.Core.MapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<ShopUser, UserDto>();
            CreateMap<IdentityUser, UserDto>();
        }
    }
}
