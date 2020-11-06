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
    public class CartProductService : CustomerBaseService<CartProduct, long, CartProductDto, ICartProductDao>, ICartProductService
    {
        private readonly ICartProductDao cartProductDao;

        public CartProductService(ICartProductDao cartProductDao, IMapper mapper) : base(cartProductDao, mapper)
        {
            this.cartProductDao = cartProductDao;
        }

        public async Task<ICollection<CartProductDto>> FindCartProductsByUsername(string username)
        {
            ICollection<CartProduct> cartProducts = await cartProductDao.FindByUserNameAsync(username);
            var cartProductWithoutEnoughtStockIds = cartProducts.Where(s => s.Quantity <= s.Size.Stock).Select(s => s.Id).ToList();
            
            if(cartProductWithoutEnoughtStockIds == null)
            {
                await base.DeleteAsync(cartProductWithoutEnoughtStockIds);
            }
            
            return cartProducts.Select(l => _mapper.Map<CartProductDto>(l)).ToList();
        }

        protected override Expression<Func<CartProduct, bool>> EntityAlreadyExistsCondition(CartProductDto dto)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<CartProduct, bool>> EntityHasDependenciesToDeleteCondition(ICollection<long> listAppIds)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(CartProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
