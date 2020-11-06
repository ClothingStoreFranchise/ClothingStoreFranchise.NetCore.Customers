using ClothingStoreFranchise.NetCore.Common.Events.Impl;

namespace ClothingStoreFranchise.NetCore.Customers.Dto.Events
{
    public class DeleteProductEvent : IntegrationEvent
    {
        public long Id { get; set; }
    }
}
