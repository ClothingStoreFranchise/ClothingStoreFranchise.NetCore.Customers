using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade
{
    public interface IProductService
    {
        Task CreateAsync(CreateProductEvent @event);

        Task UpdateAsync(UpdateProductEvent @event);

        Task DeleteAsync(long id);
    }
}
