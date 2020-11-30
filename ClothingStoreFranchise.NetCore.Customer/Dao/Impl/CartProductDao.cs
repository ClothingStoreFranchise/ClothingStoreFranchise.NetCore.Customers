using ClothingStoreFranchise.NetCore.Common.EntityFramework;
using ClothingStoreFranchise.NetCore.Customers.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dao.Impl
{
    public class CartProductDao : BaseAbstractEntitiesDao<CartProduct, long, CustomersContext>, ICartProductDao
    {
        public CartProductDao(CustomersContext contextContainer) : base(contextContainer)
        {
        }

        public async Task<ICollection<CartProduct>> FindByCustomerIdAsync(long customerId)
        {
            return await FindWhereAsync(cartProduct => cartProduct.CustomerId == customerId);
        }

        protected override IQueryable<CartProduct> QueryTemplate()
        {
            return base.QueryTemplate()
                .Include(o => o.Size.Product);
        }
    }
}
