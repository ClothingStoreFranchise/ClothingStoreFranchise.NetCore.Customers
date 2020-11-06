using ClothingStoreFranchise.NetCore.Common.Types;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dao
{
    public interface ISizeStockDao : IDao<SizeStock, long>
    {
        Task<SizeStock> FindByProductIdAndSizeWithEnoughStock(long productId, int size, long quenatity);
    }
}
