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
        private readonly ICartProductDao _cartProductDao;

        public CartProductService(ICartProductDao cartProductDao, IMapper mapper) : base(cartProductDao, mapper)
        {
            _cartProductDao = cartProductDao;
        }

        public async Task<ICollection<CartProductDto>> FindCartProductsByCustomerId(long customerId)
        {
            var cartProducts = await _cartProductDao.FindByCustomerIdAsync(customerId);
            ICollection<CartProduct> cartProductWithoutEnoughtStockIds = new List<CartProduct>();
            var cartProductsWithoutEnoughtStock = cartProducts.Where(s => s.Quantity > s.Size.Stock).ToList();

            if (cartProductsWithoutEnoughtStock.Count > 0)
            {
                await _cartProductDao.DeleteAsync(cartProductsWithoutEnoughtStock);
            }
            
            return cartProducts.Where(s=> s.Quantity <= s.Size.Stock).Select(l => _mapper.Map<CartProductDto>(l)).ToList();
        }

        public async Task<ICollection<CartProductDto>> AddUpdateCartProducts(long customerId, ICollection<CartProductDto> cartProductDtos)
        {
            ICollection<CartProduct> cartProducts = await _cartProductDao.FindByCustomerIdAsync(customerId);

            foreach (var cartProductDto in cartProductDtos)
            {
                var cartProductExisted = cartProducts.FirstOrDefault(c => c.Size.Size == cartProductDto.Size && c.Size.ProductId == cartProductDto.ProductId);
                if (cartProductExisted != null)
                {
                    cartProductExisted.Quantity += cartProductDto.Quantity;
                    await _cartProductDao.UpdateAsync(cartProductExisted);
                }
                else
                {
                    var cartProduct = _mapper.Map<CartProduct>(cartProductDto);
                    cartProduct.CustomerId = customerId;
                    await _cartProductDao.CreateAsync(cartProduct);
                }
            }

            return await FindCartProductsByCustomerId(customerId);
        }

        public async Task<CartProductDto> UpdateQuantityAsync(long productId, int quantity)
        {
            var cartProduct = await _cartProductDao.FindByIdAsync(productId);
            cartProduct.Quantity = quantity;
            var cartProductUpdated = await _cartProductDao.UpdateAsync(cartProduct);
            return _mapper.Map<CartProductDto>(cartProductUpdated);
        }

        public async Task DeleteByCustomerId(long customerId)
        {
            ICollection<CartProduct> cartProducts = await _cartProductDao.FindByCustomerIdAsync(customerId);
            await _cartProductDao.DeleteAsync(cartProducts);
        }

        protected override Expression<Func<CartProduct, bool>> EntityAlreadyExistsCondition(CartProductDto dto)
        {
            return c => c.Size.Size == dto.Size && c.Size.ProductId == dto.ProductId;
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
