using ClothingStoreFranchise.NetCore.Common.Types;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dao
{
    public interface ICartProductDao : IDao<CartProduct, long>
    {
        Task<ICollection<CartProduct>> FindByUserNameAsync(string username);
    }
}
