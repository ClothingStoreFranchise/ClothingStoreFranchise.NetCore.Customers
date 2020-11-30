using ClothingStoreFranchise.NetCore.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade
{
    public interface ISizeStockService
    {
        Task UpdateStock(ICollection<StockDto> stockDtos);

        Task<ICollection<CartProductDto>> FindByProductIdAndSizeWithEnoughStock(ICollection<CartProductDto> cartProductDtos);
    }
}
