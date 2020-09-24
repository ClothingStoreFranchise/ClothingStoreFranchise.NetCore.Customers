using ClothingStoreFranchise.NetCore.Common.EntityFramework;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dao.Impl
{
    public class CustomerDao : BaseAbstractEntitiesDao<Customer, long, CustomersContext>, ICustomerDao
    {
        public CustomerDao(CustomersContext contextContainer) : base(contextContainer)
        {
        }

        public async Task<Customer> FindByUserNameAsync(string username)
        {
            return await FindSingleWhereAsync(customer => customer.Username == username);
        }
    }
}
