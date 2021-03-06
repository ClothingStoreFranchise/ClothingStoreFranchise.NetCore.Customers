﻿using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using ClothingStoreFranchise.NetCore.Customers.Facade;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.EventHandlers
{
    public class ProductDeletedHandler : IIntegrationEventHandler<DeleteProductEvent>
    {
        private readonly IProductService _productService;

        public ProductDeletedHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task HandleAsync(DeleteProductEvent @event)
        {
            await _productService.DeleteAsync(@event.Id);
        }
    }
}