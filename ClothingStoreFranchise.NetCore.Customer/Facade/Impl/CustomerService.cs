using AutoMapper;
using ClothingStoreFranchise.NetCore.Customers.Dao;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade.Impl
{
    public class CustomerService : CustomerBaseService<Customer, long, CustomerDto, ICustomerDao>, ICustomerService
    {
        private readonly ICustomerDao _customerDao;

        public CustomerService(IMapper mapper, ICustomerDao customerDao)
            : base(customerDao, mapper)
        {
            _customerDao = customerDao;
        }

        public async Task<CustomerDto> FindByUsernameAsync(string username)
        {
            Customer customer = await _customerDao.FindByUsernameAsync(username);
            return _mapper.Map<CustomerDto>(customer);
        }

        protected override Expression<Func<Customer, bool>> EntityAlreadyExistsCondition(CustomerDto dto)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<Customer, bool>> EntityHasDependenciesToDeleteCondition(ICollection<long> listAppIds)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(CustomerDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
