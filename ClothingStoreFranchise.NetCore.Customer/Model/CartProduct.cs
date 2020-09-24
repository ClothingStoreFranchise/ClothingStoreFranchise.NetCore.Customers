using ClothingStoreFranchise.NetCore.Common.Extensible;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreFranchise.NetCore.Customers.Model
{
    public class CartProduct : ExtensibleEntity<string>
    {
        [Required]
        public string CustomerUserName { get; set; }

        [Required]
        public long ProductId { get; set; }

        [NotMapped]
        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public char Size { get; set; }

        public override string GetAppId()
        {
            throw new NotImplementedException();
        }
    }
}
