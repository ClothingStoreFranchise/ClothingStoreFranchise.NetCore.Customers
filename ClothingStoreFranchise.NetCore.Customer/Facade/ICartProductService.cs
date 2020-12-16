using ClothingStoreFranchise.NetCore.Customers.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade
{
    public interface ICartProductService
    {
        Task<CartProductDto> UpdateQuantityAsync(long productId, int quantity);

        Task<ICollection<CartProductDto>> AddUpdateCartProducts(long customerId, ICollection<CartProductDto> cartProductDtos);

        Task<ICollection<CartProductDto>> FindCartProductsByCustomerId(long customerId);

        Task DeleteAsync(long id);

        Task DeleteByCustomerId(long customerId);
    }
}
