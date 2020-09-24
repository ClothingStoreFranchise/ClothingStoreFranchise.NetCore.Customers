using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreFranchise.NetCore.Customers.Model
{
    public class Cart
    {
        [Key]
        public Guid CustomerId { get; set; }


        [NotMapped]
        public ICollection<CartProduct> Products { get; set; }
    }
}
