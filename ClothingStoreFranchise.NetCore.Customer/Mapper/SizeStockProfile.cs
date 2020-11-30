using AutoMapper;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Model;

namespace ClothingStoreFranchise.NetCore.Customers.Mapper
{
    public class SizeStockProfile : Profile
    {
        public SizeStockProfile()
        {
            CreateMap<StockDto, SizeStock>();

            CreateMap<SizeStock, StockDto>();
        }
    }
}
