using ClothingStoreFranchise.NetCore.Common.Events.Impl;
using ClothingStoreFranchise.NetCore.Common.Types;
using System.Collections.Generic;

namespace ClothingStoreFranchise.NetCore.Customers.Dto.Events
{
    public class UpdateStockEvent : IntegrationEvent
    {
        public ICollection<StockDto> Stocks { get; set; }
    }
}
