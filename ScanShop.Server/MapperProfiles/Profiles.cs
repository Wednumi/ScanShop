using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ScanShop.Db.Entities;
using ScanShop.Shared.Dto;
using ScanShop.Shared.Dto.Product;
using ScanShop.Shared.Dto.User;

namespace ContextStudier.Core.MapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<ShopUser, UserDto>();
            CreateMap<IdentityUser, UserDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(src => src.Category.Title));
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
