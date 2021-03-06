﻿using AutoMapper;
using ClothingStoreFranchise.NetCore.Customers.Dao;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Model;

namespace ClothingStoreFranchise.NetCore.Customers.Mapper
{
    public class CartProductProfile : Profile
    {
        public CartProductProfile()
        {
            CreateMap<CartProduct, CartProductDto>()
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Size.Stock))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.Size))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Size.Product.Name))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Size.Product.Id))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Size.Product.UnitPrice))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.Size.Product.PictureUrl))
                .ForMember(dest => dest.ClothingSizeType, opt => opt.MapFrom(src => src.Size.Product.ClothingSizeType));

            CreateMap<CartProductBaseDto, CartProduct>()
                .ForMember(dest => dest.Size, opt => opt.Ignore())
                .AfterMap<TrackCartProductAction>();

            CreateMap<SizeStock, CartProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.UnitPrice))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.Product.PictureUrl))
                .ForMember(dest => dest.ClothingSizeType, opt => opt.MapFrom(src => src.Product.ClothingSizeType));
        }
    }

    public class TrackCartProductAction : IMappingAction<CartProductBaseDto, CartProduct>
    {
        private readonly ISizeStockDao _sizeStockDao;

        public TrackCartProductAction(ISizeStockDao sizeStockDao)
        {
            _sizeStockDao = sizeStockDao;
        }


        public void Process(CartProductBaseDto source, CartProduct destination, ResolutionContext context)
        {
            TrackCategory(source, destination);
        }

        public void TrackCategory(CartProductBaseDto dto, CartProduct entity)
        {
            SizeStock size = _sizeStockDao.FindByProductIdAndSizeWithEnoughStock(dto.ProductId, dto.Size, dto.Quantity).Result;
            entity.Size = size;
        }
    }
}
