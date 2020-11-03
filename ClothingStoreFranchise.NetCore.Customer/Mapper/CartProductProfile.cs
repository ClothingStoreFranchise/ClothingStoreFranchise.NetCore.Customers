using AutoMapper;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Model;

namespace ClothingStoreFranchise.NetCore.Customers.Mapper
{
    public class CartProductProfile : Profile
    {
        public CartProductProfile()
        {
            CreateMap<CartProduct, CartProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.UnitPrice))
                .ForMember(dest => dest.ClothingSizeType, opt => opt.MapFrom(src => src.Product.ClothingSizeType));
        }
    }
}
