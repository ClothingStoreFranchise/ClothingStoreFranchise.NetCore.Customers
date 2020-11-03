using ClothingStoreFranchise.NetCore.Common.Extensible;
using System.ComponentModel.DataAnnotations;

namespace ClothingStoreFranchise.NetCore.Customers.Model
{
    public class CartProduct : ExtensibleEntity<long>
    {
        [Required]
        public string CustomerUsername { get; set; }

        [Required]
        public long ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public char Size { get; set; }

        public override long GetAppId()
        {
            return Id;
        }
    }
}
