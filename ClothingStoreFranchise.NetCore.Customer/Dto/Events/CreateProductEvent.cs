using ClothingStoreFranchise.NetCore.Common.Events.Impl;

namespace ClothingStoreFranchise.NetCore.Customers.Dto.Events
{
    public class CreateProductEvent : IntegrationEvent
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal UnitPrice { get; set; }

        public string PictureUrl { get; set; }
    }
}
