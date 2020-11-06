using ClothingStoreFranchise.NetCore.Common.EntityFramework;
using ClothingStoreFranchise.NetCore.Customers.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dao.Impl
{
    public class SizeStockDao : BaseAbstractEntitiesDao<SizeStock, long, CustomersContext>, ISizeStockDao
    {
        public SizeStockDao(CustomersContext contextContainer) : base(contextContainer)
        {
        }

        public async Task<SizeStock> FindByProductIdAndSizeWithEnoughStock(long productId, int size, long quenatity)
        {
            return await FindSingleWhereAsync(stock => stock.Size == size && stock.Stock <= quenatity && stock.Product.Id == productId);
        }

        protected override IQueryable<SizeStock> QueryTemplate()
        {
            return base.QueryTemplate()
                .Include(o => o.Product);
        }
    }
}
