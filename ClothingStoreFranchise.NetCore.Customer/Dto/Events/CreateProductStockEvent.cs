using ClothingStoreFranchise.NetCore.Common.Events.Impl;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dto.Events
{
    public class CreateProductStockEvent : IntegrationEvent
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal UnitPrice { get; set; }

        public string PictureUrl { get; set; }

        public List<SizeStock> totalWarehouseStock { get; set; }
    }
}
