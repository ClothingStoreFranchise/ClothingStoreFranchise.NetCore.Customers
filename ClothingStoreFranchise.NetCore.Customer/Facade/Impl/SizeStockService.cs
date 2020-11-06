using AutoMapper;
using ClothingStoreFranchise.NetCore.Customers.Dao;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade.Impl
{
    public class SizeStockService : CustomerBaseService<SizeStock, long, CartProductDto, ISizeStockDao>, ISizeStockService
    {
        private readonly ISizeStockDao _sizeStockDao;

        public SizeStockService(ISizeStockDao sizeStockDao, IMapper mapper) : base(sizeStockDao, mapper)
        {
            _sizeStockDao = sizeStockDao;
        }

        public async Task<ICollection<CartProductDto>> FindByProductIdAndSizeWithEnoughStock(ICollection<CartProductDto> cartProductDtos)
        {
            var sizeStocks = new List<SizeStock>();
            foreach (var cartProduct in cartProductDtos)
            {
                SizeStock sizeStock = await _sizeStockDao.FindByProductIdAndSizeWithEnoughStock(cartProduct.Id, cartProduct.Size, cartProduct.Quantity);
                sizeStocks.Add(sizeStock);
            }

            return sizeStocks.Select(l => _mapper.Map<CartProductDto>(l)).ToList(); ;
        }

        protected override Expression<Func<SizeStock, bool>> EntityAlreadyExistsCondition(CartProductDto dto)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<SizeStock, bool>> EntityHasDependenciesToDeleteCondition(ICollection<long> listAppIds)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(CartProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
