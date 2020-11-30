using ClothingStoreFranchise.NetCore.Common.Events.Impl;
using ClothingStoreFranchise.NetCore.Common.Types;

namespace ClothingStoreFranchise.NetCore.Customers.Dto.Events
{
    public class DeleteProductEvent : IntegrationEvent, IEntityDto<long>
    {
        public long Id { get; set; }

        public long Key()
        {
            return Id;
        }
    }
}
