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

    public class ProductService : CustomerBaseService<Product, long, ProductDto, IProductDao>, IProductService
    {

        private readonly IProductDao _productDao;

        public ProductService(IProductDao productDao, IMapper mapper) : base(productDao, mapper)
        {
            _productDao = productDao;
        }

        public async Task CreateAsync(CreateProductEvent @event)
        {
            //await CreateValidationActionsAsync(dto);
            Product product = _mapper.Map<Product>(@event);
            await CreateActionsAsync(product);
        }

        public async Task UpdateAsync(UpdateProductEvent @event)
        {
            Product product = _mapper.Map<Product>(@event);
            await _productDao.UpdateAsync(product);
        }

        protected override Expression<Func<Product, bool>> EntityAlreadyExistsCondition(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<Product, bool>> EntityHasDependenciesToDeleteCondition(ICollection<long> listAppIds)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(ProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
