using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.EventHandlers
{
    public class StockUpdatedHandler : IIntegrationEventHandler<UpdateStockEvent>
    {
        public StockUpdatedHandler()
        {

        }

        public async Task HandleAsync(UpdateStockEvent @event)
        {
            var a = @event.Size;
            var b = 1;
        }
    }
}
