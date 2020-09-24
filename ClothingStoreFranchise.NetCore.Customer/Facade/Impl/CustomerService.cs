using AutoMapper;
using ClothingStoreFranchise.NetCore.Customers.Dao;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using ClothingStoreFranchise.NetCore.Customers.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Facade.Impl
{
    public class CustomerService : CustomerBaseService<Customer, long, CustomerDto, ICustomerDao>, ICustomerService
    {
        private readonly ICustomerDao _customerDao;
        private readonly ICustomersIntegrationEventService _customersIntegrationEventService;

        public CustomerService(ICustomerDao customerDao, IMapper mapper, ICustomersIntegrationEventService customersIntegrationEventService)
            : base(customerDao, mapper)
        {
            _customersIntegrationEventService = customersIntegrationEventService;
            _customerDao = customerDao;
        }

        public async Task CreateCustomerAsync(CustomerDto customerDto)
        {
            await base.CreateAsync(customerDto);
            var registerUserEvent = _mapper.Map<RegisterUserEvent>(customerDto);
            registerUserEvent.Role = "CUSTOMER";
            await _customersIntegrationEventService.SaveEventAndCustomersContextChangesAsync(registerUserEvent);
            await _customersIntegrationEventService.PublishThroughEventBusAsync(registerUserEvent);
        }

        public async Task<CustomerDto> FindByUserNameAsync(string userName)
        {
            Customer customer = await _customerDao.FindByUserNameAsync(userName);
            return _mapper.Map<CustomerDto>(customer);
        }

        protected override Expression<Func<Customer, bool>> EntityAlreadyExistsCondition(CustomerDto dto)
        {
            return c => c.Username == dto.Username;
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
