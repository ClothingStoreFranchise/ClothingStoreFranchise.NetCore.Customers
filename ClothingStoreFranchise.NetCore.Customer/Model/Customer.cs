using ClothingStoreFranchise.NetCore.Common.Extensible;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreFranchise.NetCore.Customers.Model
{
    public class Customer : ExtensibleEntity<long> 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override long Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Address { get; set; }
                
        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string CardNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }

        public override long GetAppId()
        {
            return Id;
        }
    }
}
