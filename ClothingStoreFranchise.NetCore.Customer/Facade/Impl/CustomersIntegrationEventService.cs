using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Common.Events.Impl;
using ClothingStoreFranchise.NetCore.Common.RabbitMq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade.Impl
{
    public class CustomersIntegrationEventService: ICustomersIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventBus _eventBus;
        private readonly CustomersContext _customersContext;
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly ILogger<CustomersIntegrationEventService> _logger;

        public CustomersIntegrationEventService(
            ILogger<CustomersIntegrationEventService> logger,
            CustomersContext databaseContext,
            IEventBus eventBus,
            Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customersContext = databaseContext ?? throw new ArgumentNullException(nameof(_customersContext));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventLogService = _integrationEventLogServiceFactory(_customersContext.Database.GetDbConnection());
        }

        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            try
            {
                _logger.LogInformation("----- Publishing integration event: {IntegrationEventId_published} from {AppName} - ({@IntegrationEvent})", evt.EventId, Program.AppName, evt);

                await _eventLogService.MarkEventAsInProgressAsync(evt.EventId);
                _eventBus.Publish(evt);
                await _eventLogService.MarkEventAsPublishedAsync(evt.EventId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", evt.EventId, Program.AppName, evt);
                await _eventLogService.MarkEventAsFailedAsync(evt.EventId);
            }
        }

        public async Task SaveEventAndCustomersContextChangesAsync(IntegrationEvent evt)
        {
            _logger.LogInformation("IntegrationEventService - Saving changes and integrationEvent: {IntegrationEventId}", evt.EventId);

            // Entity Framework Core resiliency strategy
            // https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
            await ResilientTransaction.New(_customersContext).ExecuteAsync(async () =>
            {
                // Achieving atomicity between original customers database operation and the IntegrationEventLog thanks to a local transaction
                await _customersContext.SaveChangesAsync();
                await _eventLogService.SaveEventAsync(evt, _customersContext.Database.CurrentTransaction);
            });
        }
    }
}
