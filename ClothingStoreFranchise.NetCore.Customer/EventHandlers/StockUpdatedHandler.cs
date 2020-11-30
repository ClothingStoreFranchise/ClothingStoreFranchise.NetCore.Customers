using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using ClothingStoreFranchise.NetCore.Customers.Facade;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.EventHandlers
{
    public class StockUpdatedHandler : IIntegrationEventHandler<UpdateStockEvent>
    {
        private readonly ISizeStockService _sizeStockService;

        public StockUpdatedHandler(ISizeStockService sizeStockService)
        {
            _sizeStockService = sizeStockService;
        }

        public async Task HandleAsync(UpdateStockEvent @event)
        {
            await _sizeStockService.UpdateStock(@event.Stocks);
        }
    }
}
