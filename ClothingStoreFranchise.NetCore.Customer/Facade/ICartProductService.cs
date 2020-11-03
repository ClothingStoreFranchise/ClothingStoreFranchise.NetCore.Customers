using ClothingStoreFranchise.NetCore.Customers.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade
{
    public interface ICartProductService
    {
        Task<ICollection<CartProductDto>> CreateAsync(ICollection<CartProductDto> cartProductDtos);

        Task<CartProductDto> UpdateAsync(CartProductDto cartProductDto);

        Task<ICollection<CartProductDto>> FindCartProductsByUsername(string username);

        Task DeleteAsync(ICollection<long> listAppId);
    }
}
