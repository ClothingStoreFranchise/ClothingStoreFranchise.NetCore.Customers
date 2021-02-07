using ClothingStoreFranchise.NetCore.Customers.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateAsync(CustomerDto customerDto);

        Task<CustomerDto> UpdateAsync(CustomerDto customer);

        Task<CustomerDto> UpdateCustomerAfterCheckoutAsync(CustomerDto customerDto);

        Task DeleteAsync(long id);

        Task<ICollection<CustomerDto>> LoadAllAsync();

        Task<CustomerDto> FindByUsernameAsync(string username);
    }
}

