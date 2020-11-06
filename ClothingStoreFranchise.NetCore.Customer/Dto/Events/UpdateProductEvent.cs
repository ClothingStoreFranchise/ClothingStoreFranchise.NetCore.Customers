using ClothingStoreFranchise.NetCore.Common.Constants;
using ClothingStoreFranchise.NetCore.Common.Events.Impl;

namespace ClothingStoreFranchise.NetCore.Customers.Dto.Events
{
    public class UpdateProductEvent : IntegrationEvent
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public string PictureUrl { get; set; }

        public ClothingSizeType ClothingSizeType { get; set; }
    }
}
