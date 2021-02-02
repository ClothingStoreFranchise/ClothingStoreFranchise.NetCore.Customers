using ClothingStoreFranchise.NetCore.Common.Types;
using System;
using System.Collections.Generic;

namespace ClothingStoreFranchise.NetCore.Customers.Dto
{
    public class CustomerDto : IEntityDto<long>
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ICollection<CartProductBaseDto> CartProducts { get; set; }

        public long Key() => Id;
    }
}
