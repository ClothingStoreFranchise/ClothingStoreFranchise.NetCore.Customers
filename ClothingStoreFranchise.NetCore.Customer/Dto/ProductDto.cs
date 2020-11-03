using ClothingStoreFranchise.NetCore.Common.Extensible;
using ClothingStoreFranchise.NetCore.Common.Types;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dto
{
    public class ProductDto : BaseExtensibleEntityDto, IEntityDto<long>
    {
        public long Id { get; set; }

        public string Name { get; private set; }

        public decimal UnitPrice { get; private set; }

        public int Quantity { get; private set; }

        public long Key() => Id;

        public override string ExtensibleEntityName => typeof(Product).Name;
    }
}
