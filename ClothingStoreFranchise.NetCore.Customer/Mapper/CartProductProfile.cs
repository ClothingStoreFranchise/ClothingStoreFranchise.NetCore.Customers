using AutoMapper;
using ClothingStoreFranchise.NetCore.Customers.Dao;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Mapper
{
    public class CartProductProfile : Profile
    {
        public CartProductProfile()
        {
            CreateMap<CartProduct, CartProductDto>()
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.Size))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Size.Product.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Size.Product.UnitPrice))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.Size.Product.PictureUrl))
                .ForMember(dest => dest.ClothingSizeType, opt => opt.MapFrom(src => src.Size.Product.ClothingSizeType));
            CreateMap<CartProductDto, CartProduct>()
                .AfterMap<TrackCartProductAction>();
            CreateMap<SizeStock, CartProductDto>();
        }
    }

    public class TrackCartProductAction : IMappingAction<CartProductDto, CartProduct>
    {
        private readonly ISizeStockDao _sizeStockDao;

        public TrackCartProductAction(ISizeStockDao sizeStockDao)
        {
            _sizeStockDao = sizeStockDao;
        }


        public void Process(CartProductDto source, CartProduct destination, ResolutionContext context)
        {
            TrackCategory(source, destination);
        }

        public void TrackCategory(CartProductDto dto, CartProduct entity)
        {
            SizeStock size = _sizeStockDao.FindByProductIdAndSizeWithEnoughStock(dto.Id, dto.Size, dto.Quantity).Result;
            entity.Size = size;
        }
    }
}
