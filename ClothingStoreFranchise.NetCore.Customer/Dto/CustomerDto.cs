using ClothingStoreFranchise.NetCore.Common.Extensible;
using ClothingStoreFranchise.NetCore.Common.Types;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dto
{
    public class CustomerDto : IEntityDto<long>
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public ICollection<CartProductDto> Products { get; set; }

        public long Key() => Id;
    }
}
