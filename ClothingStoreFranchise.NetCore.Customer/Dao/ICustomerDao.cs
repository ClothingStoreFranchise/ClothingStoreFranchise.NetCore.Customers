using ClothingStoreFranchise.NetCore.Common.Types;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dao
{
    public interface ICustomerDao : IDao<Customer, long>
    {
        Task<Customer> FindByUsernameAsync(string userName);
    }
}
