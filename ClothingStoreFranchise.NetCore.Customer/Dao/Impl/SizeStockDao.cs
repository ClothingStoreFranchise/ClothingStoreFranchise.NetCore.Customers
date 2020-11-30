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

        public async Task<SizeStock> FindByProductIdAndSizeWithEnoughStock(long productId, int size, long quantity)
        {
            return await FindSingleWhereAsync(stock => stock.Size == size && quantity  <= stock.Stock && stock.Product.Id == productId);
        }

        public async Task<SizeStock> FindByProductIdAndSize(long productId, int size)
        {
            return await FindSingleWhereAsync(stock => stock.Size == size && stock.Product.Id == productId);
        }

        protected override IQueryable<SizeStock> QueryTemplate()
        {
            return base.QueryTemplate()
                .Include(o => o.Product);
        }
    }
}
