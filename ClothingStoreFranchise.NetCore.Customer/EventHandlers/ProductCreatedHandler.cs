using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using ClothingStoreFranchise.NetCore.Customers.Facade;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.EventHandlers
{
    public class ProductCreatedHandler : IIntegrationEventHandler<CreateProductEvent>
    {
        private readonly IProductService _productService;

        public ProductCreatedHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task HandleAsync(CreateProductEvent @event)
        {
            await _productService.CreateAsync(@event);
        }
    }
}
