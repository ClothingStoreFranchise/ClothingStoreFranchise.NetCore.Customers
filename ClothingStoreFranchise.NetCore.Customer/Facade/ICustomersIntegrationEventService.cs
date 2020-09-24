using ClothingStoreFranchise.NetCore.Common.Events.Impl;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade
{
    public interface ICustomersIntegrationEventService
    {
        Task SaveEventAndCustomersContextChangesAsync(IntegrationEvent evt);
        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
