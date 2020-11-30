using ClothingStoreFranchise.NetCore.Common.EntityFramework;
using ClothingStoreFranchise.NetCore.Customers.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Dao.Impl
{
    public class CustomerDao : BaseAbstractEntitiesDao<Customer, long, CustomersContext>, ICustomerDao
    {
        public CustomerDao(CustomersContext contextContainer) : base(contextContainer)
        {
        }

        public async Task<Customer> FindByUsernameAsync(string username)
        {
            return await FindSingleWhereAsync(customer => customer.Username == username);
        }

        /*protected override IQueryable<Customer> QueryTemplate()
        {
            return base.QueryTemplate()
                .Include(o => o.CartProducts).Include(s => s);
        }*/
    }
}
