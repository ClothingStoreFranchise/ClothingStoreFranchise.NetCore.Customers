using ClothingStoreFranchise.NetCore.Common.Events.Impl;

namespace ClothingStoreFranchise.NetCore.Customers.Dto.Events
{
    public class ProductCreatedEvent : IntegrationEvent
    {
        public long ProductId { get; set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }
    }
}