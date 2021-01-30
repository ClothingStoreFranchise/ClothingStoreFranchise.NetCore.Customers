using Autofac;
using AutoMapper;
using ClothingStoreFranchise.NetCore.Catalog.Facade.Impl;
using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Common.RabbitMq;
using ClothingStoreFranchise.NetCore.Common.RabbitMq.Impl;
using ClothingStoreFranchise.NetCore.Customers.Dao;
using ClothingStoreFranchise.NetCore.Customers.Dao.Impl;
using ClothingStoreFranchise.NetCore.Customers.EventHandlers;
using ClothingStoreFranchise.NetCore.Customers.Facade;
using ClothingStoreFranchise.NetCore.Customers.Facade.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace ClothingStoreFranchise.NetCore.Customers
{
    public static class CustomersServiceCollection
    {
        public static void AddCustomersServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerDao, CustomerDao>();
            services.AddScoped<IProductDao, ProductDao>();
            services.AddScoped<ICartProductDao, CartProductDao>();
            services.AddScoped<ISizeStockDao, SizeStockDao>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartProductService, CartProductService>();
            services.AddScoped<ISizeStockService, SizeStockService>();

            services.AddTransient<ICustomersIntegrationEventService, CustomersIntegrationEventService>();
            services.AddAutoMapper(typeof(Startup).GetTypeInfo().Assembly);
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, RabbitMqOptions options)
        {

            var subscriptionClientName = options.Namespace;

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = options.Retries;

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            services.AddTransient<ProductCreatedHandler>();
            services.AddTransient<ProductUpdatedHandler>();
            services.AddTransient<ProductDeletedHandler>();
            services.AddTransient<StockUpdatedHandler>();

            return services;
        }

        public static IServiceCollection AddIntegrationServices(this IServiceCollection services, RabbitMqOptions options)
        {

            services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
                sp => (DbConnection c) => new IntegrationEventLogService(c));

            services.AddTransient<ICustomersIntegrationEventService, CustomersIntegrationEventService>();

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<RabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = options.Hostnames.FirstOrDefault(),
                    DispatchConsumersAsync = true
                };

                factory.UserName = options.Username;

                factory.Password = options.Password;

                var retryCount = options.Retries;

                return new RabbitMQPersistentConnection(factory, logger, retryCount);
            });

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomersContext>(options =>
            {
                options.UseSqlServer(@"data source=127.0.0.1; initial catalog=Customer; persist security info=True; user id=sqlserver; password=root",
                                     sqlServerOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                         //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                     });
            });

            services.AddDbContext<IntegrationEventLogContext>(options =>
            {
                options.UseSqlServer(@configuration["DatabaseConnection"],
                                     sqlServerOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                         //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                     });
            });

            return services;
        }
    }
}
