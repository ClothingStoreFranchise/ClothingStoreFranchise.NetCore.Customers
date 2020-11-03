using ClothingStoreFranchise.NetCore.Common.Extensible;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreFranchise.NetCore.Customers.Model
{
    public class Customer : ExtensibleEntity<long> 
    {   
        [Required]
        public string Username { get; set; }

        public string LastName { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }
                
        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public ICollection<CartProduct> CartProducts { get; set; }

        public override long GetAppId()
        {
            throw new NotImplementedException();
        }
    }
}
