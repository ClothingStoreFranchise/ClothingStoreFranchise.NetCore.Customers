using ClothingStoreFranchise.NetCore.Common.Extensible;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Model
{
    public class SizeStock : ExtensibleEntity<long>
    {
        [ForeignKey("Product")]
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Size { get; set; }

        public long Stock { get; set; }

        public override long GetAppId()
        {
            return Id;
        }
    }
}
