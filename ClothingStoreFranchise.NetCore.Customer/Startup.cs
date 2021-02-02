using Autofac;
using Autofac.Extensions.DependencyInjection;
using ClothingStoreFranchise.NetCore.Common.Constants;
using ClothingStoreFranchise.NetCore.Common.Extensible;
using ClothingStoreFranchise.NetCore.Common.Mapper;
using ClothingStoreFranchise.NetCore.Common.RabbitMq;
using ClothingStoreFranchise.NetCore.Common.RabbitMq.Impl;
using ClothingStoreFranchise.NetCore.Common.Security;
using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using ClothingStoreFranchise.NetCore.Customers.EventHandlers;
using ClothingStoreFranchise.NetCore.Customers.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Discovery.Client;
using System;

namespace ClothingStoreFranchise.NetCore.Customers
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        protected IMapperProvider MapperProvider { get; } = new CustomersMapperProvider();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var options = Configuration.GetOptions<RabbitMqOptions>("rabbitMq");

            services.AddEventBus(options);
            services.AddIntegrationServices(options);
            services.AddDiscoveryClient(Configuration);
            services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddAuthentication("Basic")
                 .AddScheme<BasicAuthenticationOptions, CustomAuthenticationHandler>("Basic", null);

            services.AddAuthorization(config =>
            {
                //UPDATE is new in common
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.Customer, Policies.CustomerAdminPolicy());
            });

            services.AddCustomersServices();

            services.AddCustomDbContext(Configuration);

            services.AddSingleton(MapperProvider);

            services.AddSwaggerGen(x =>
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }));

            var container = new ContainerBuilder();
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/error");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseDiscoveryClient();

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            //catalog microservice events
            eventBus.Subscribe<CreateProductEvent, ProductCreatedHandler>();
            eventBus.Subscribe<UpdateProductEvent, ProductUpdatedHandler>();
            eventBus.Subscribe<DeleteProductEvent, ProductDeletedHandler>();
            //inventory microservice events
            eventBus.Subscribe<UpdateStockEvent, StockUpdatedHandler>();
        }
    }
}
