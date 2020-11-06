using ClothingStoreFranchise.NetCore.Common.Events.Impl;

namespace ClothingStoreFranchise.NetCore.Customers.Dto.Events
{
    public class UpdateStockEvent : IntegrationEvent
    {
        public long ProductId { get; set; }

        public int Size { get; set; }

        public long Stock { get; set; }
    }
}
