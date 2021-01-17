﻿using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Facade;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Controllers
{
    [Route("cart")]
    [ApiController]
    public class CartProductController : ControllerBase
    {
        private readonly ICartProductService _cartProductService;

        private readonly ISizeStockService _stockService;

        public CartProductController(ICartProductService cartProductService, ISizeStockService stockService)
        {
            _cartProductService = cartProductService;
            _stockService = stockService;
        }

        [HttpPost]
        public async Task<ActionResult<ICollection<CartProductDto>>> GetWithoutLogIn([FromBody] ICollection<CartProductDto> cartProductDtos)
        {
            return Ok(await _stockService.FindByProductIdAndSizeWithEnoughStock(cartProductDtos));
        }

        [HttpPut]
        public async Task<ActionResult<CartProductDto>> UpdateQuantity([FromBody] CartProductDto cartProductDto)
        {
            return Ok(await _cartProductService.UpdateQuantityAsync(cartProductDto.Id, cartProductDto.Quantity));
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<ICollection<CartProductDto>>> GetByCustomer(long customerId)
        {
            return Ok(await _cartProductService.FindCartProductsByCustomerId(customerId));
        }

        [HttpPut("customer/{customerId}")]
        public async Task<ActionResult<ICollection<CartProductDto>>> CreateOrUpdateIfExistMultiple(long customerId, [FromBody] ICollection<CartProductBaseDto> cartProducts)
        {
            return Ok(await _cartProductService.AddUpdateCartProducts(customerId, cartProducts));
        }

        [HttpDelete("customer/{customerId}")]
        public async Task DeleteByCustomerId(long customerId)
        {
            await _cartProductService.DeleteByCustomerId(customerId);
        }

        [HttpDelete("{cartProductId}")]
        public async Task Delete(long cartProductId)
        {
            await _cartProductService.DeleteAsync(cartProductId);
        }
    }
}
