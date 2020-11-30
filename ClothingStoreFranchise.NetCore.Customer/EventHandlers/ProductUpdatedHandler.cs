using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using ClothingStoreFranchise.NetCore.Customers.Facade;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.EventHandlers
{
    public class ProductUpdatedHandler : IIntegrationEventHandler<UpdateProductEvent>
    {

        private readonly IProductService _productService;

        public ProductUpdatedHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task HandleAsync(UpdateProductEvent @event)
        {
            await _productService.UpdateAsync(@event);
        }
    }
}
