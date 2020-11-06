using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.EventHandlers
{
    public class ProductDeletedHandler : IIntegrationEventHandler<DeleteProductEvent>
    {
        public ProductDeletedHandler()
        {
        }

        public async Task HandleAsync(DeleteProductEvent @event)
        {
            var a = @event.Id;
            var b = 1;
        }
    }
}
