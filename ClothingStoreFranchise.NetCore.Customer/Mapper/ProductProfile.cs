using AutoMapper;
using ClothingStoreFranchise.NetCore.Common.Extensible;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Model;

namespace ClothingStoreFranchise.NetCore.Customers.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().IncludeBase<IExtensibleEntity, BaseExtensibleEntityDto>();

            CreateMap<ProductDto, Product>().IncludeBase<BaseExtensibleEntityDto, IExtensibleEntity>();

            /*.ForMember(entity => entity., p => p.Ignore())
            .ForMember(entiy => entiy.Offers, p => p.Ignore())
            .ForMember(entity => entity.CatalogProductId, p => p.Ignore());*/
        }
    }
}
