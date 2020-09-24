using ClothingStoreFranchise.NetCore.Customers.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CustomerDto customerDto);

        Task<ICollection<CustomerDto>> CreateAsync(ICollection<CustomerDto> customer);

        Task<CustomerDto> UpdateAsync(CustomerDto customer);

        Task DeleteAsync(ICollection<long> listAppId);

        Task<ICollection<CustomerDto>> LoadAllAsync();

        Task<CustomerDto> FindByUserNameAsync(string appId);
    }
}

