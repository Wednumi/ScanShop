using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ScanShop.Db.Entities;
using ScanShop.Shared.Dto;
using ScanShop.Shared.Dto.User;

namespace ScanShop.Server.MapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<ShopUser, UserDto>();
            CreateMap<IdentityUser, UserDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(src => src.Category.Title));
            CreateMap<ProductDto, Product>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<Order, OrderDto>()
                .ForMember(dto => dto.CustomerFullName,
                    opt => opt.MapFrom(src => src.User.Name + " " + src.User.LastName))
                .ForMember(dto => dto.OrderItems,
                    opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItemDto, OrderItem>();
        }
    }
}
