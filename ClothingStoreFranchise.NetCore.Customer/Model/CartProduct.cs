using ClothingStoreFranchise.NetCore.Common.Extensible;

namespace ClothingStoreFranchise.NetCore.Customers.Model
{
    public class CartProduct : ExtensibleEntity<long>
    {
        public long CustomerId { get; set; }

        public int Quantity { get; set; }

        public virtual SizeStock Size { get; set; }

        public override long GetAppId()
        {
            return Id;
        }
    }
}
