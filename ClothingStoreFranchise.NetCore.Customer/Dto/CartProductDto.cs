using ClothingStoreFranchise.NetCore.Common.Extensible;
using ClothingStoreFranchise.NetCore.Common.Types;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dto
{
    public class CartProductDto : BaseExtensibleEntityDto, IEntityDto<long>
    {
        public long Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public long ProductId { get; set; }

        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public char Size { get; set; }

        public long Key() => Id;

        public override string ExtensibleEntityName => typeof(CartProduct).Name;
    }
}
