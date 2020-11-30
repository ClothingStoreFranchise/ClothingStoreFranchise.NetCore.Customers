using AutoMapper;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Model;

namespace ClothingStoreFranchise.NetCore.Customers.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //CreateMap<Customer, CustomerDto>().IncludeBase<IExtensibleEntity, BaseExtensibleEntityDto>();

            //CreateMap<CustomerDto, Customer>().IncludeBase<BaseExtensibleEntityDto, IExtensibleEntity>();

            CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.CartProducts, opt => opt.Ignore());

            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.CartProducts, opt => opt.Ignore());
        }
    }
}
