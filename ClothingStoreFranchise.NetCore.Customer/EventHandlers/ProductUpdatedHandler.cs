using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.EventHandlers
{
    public class ProductUpdatedHandler : IIntegrationEventHandler<UpdateProductEvent>
    {
        public ProductUpdatedHandler()
        {
        }

        public async Task HandleAsync(UpdateProductEvent @event)
        {
            var a = @event.Id;
            var b = 1;
        }
    }
}
