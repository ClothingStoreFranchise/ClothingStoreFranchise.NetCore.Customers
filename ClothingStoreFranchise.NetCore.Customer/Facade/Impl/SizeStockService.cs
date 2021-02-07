using AutoMapper;
using ClothingStoreFranchise.NetCore.Customers.Dao;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade.Impl
{
    public class SizeStockService : CustomerBaseService<SizeStock, long, StockDto, ISizeStockDao>, ISizeStockService
    {
        private readonly ISizeStockDao _sizeStockDao;

        public SizeStockService(ISizeStockDao sizeStockDao, IMapper mapper) : base(sizeStockDao, mapper)
        {
            _sizeStockDao = sizeStockDao;
        }

        public async Task<ICollection<CartProductDto>> FindByProductIdAndSizeWithEnoughStock(ICollection<CartProductDto> cartProductDtos)
        {
            var cartLoaded = new List<CartProductDto>();
            foreach (var cartProduct in cartProductDtos)
            {
                SizeStock sizeStock = await _sizeStockDao.FindByProductIdAndSizeWithEnoughStock(cartProduct.ProductId, cartProduct.Size, cartProduct.Quantity);

                if (sizeStock != null)
                {
                    var cartProductLoaded = _mapper.Map<CartProductDto>(sizeStock);

                    cartProductLoaded.Quantity = cartProduct.Quantity;
                    cartLoaded.Add(cartProductLoaded);
                }
            }

            return cartLoaded;
        }

        public async Task UpdateStock(ICollection<StockDto> stockDtos)
        {
            foreach(var stock in stockDtos)
            {
                SizeStock stockLoaded = await _sizeStockDao.FindByProductIdAndSize(stock.ProductId, stock.Size);
                if (stockLoaded != null)
                {
                    stockLoaded = _mapper.Map(stock, stockLoaded);
                    await _entityDao.UpdateAsync(stockLoaded);
                }
                else
                {
                    await CreateAsync(stock);
                }
            }
        }

        protected override Expression<Func<SizeStock, bool>> EntityAlreadyExistsCondition(StockDto dto)
        {
            return c => c.ProductId == dto.ProductId && c.Size == dto.Size;
        }

        protected override Expression<Func<SizeStock, bool>> EntityAlreadyExistsToUpdateCondition(StockDto dto)
        {
            return c => c.ProductId == dto.ProductId && c.Size == dto.Size;
        }

        protected override Expression<Func<SizeStock, bool>> EntityHasDependenciesToDeleteCondition(ICollection<long> listAppIds)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(StockDto dto)
        {
            return dto.Stock >= 0;
        }
    }
}
