using ClothingStoreFranchise.NetCore.Common.Extensible;
using System;

namespace ClothingStoreFranchise.NetCore.Customers.Model
{
    public class Product : ExtensibleEntity<long>
    {
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int Stock { get; set; }

        public string PictureUrl { get; set; }

        /*public Product(long id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }*/

        public override long GetAppId()
        {
            throw new NotImplementedException();
        }
    }
}
