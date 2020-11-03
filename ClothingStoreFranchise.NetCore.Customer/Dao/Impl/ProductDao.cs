using ClothingStoreFranchise.NetCore.Common.EntityFramework;
using ClothingStoreFranchise.NetCore.Customers.Model;

namespace ClothingStoreFranchise.NetCore.Customers.Dao.Impl
{
    public class ProductDao : BaseAbstractEntitiesDao<Product, long, CustomersContext>, IProductDao
    {
        public ProductDao(CustomersContext contextContainer) : base(contextContainer)
        {
        }
    }
}
