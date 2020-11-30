using ClothingStoreFranchise.NetCore.Customers.Dto;
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

        [HttpPut]
        public async Task<ActionResult<ICollection<CartProductDto>>> GetWithoutLogIn([FromBody] ICollection<CartProductDto> cartProductDtos)
        {
            return Ok(await _stockService.FindByProductIdAndSizeWithEnoughStock(cartProductDtos));
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<ICollection<CartProductDto>>> GetByCustomer(long customerId)
        {
            return Ok(await _cartProductService.FindCartProductsByCustomerId(customerId));
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult<ICollection<CartProductDto>>> CreateOrUpdateIfExistMultiple(long customerId, [FromBody] ICollection<CartProductDto> cartProducts)
        {
            return Ok(await _cartProductService.AddUpdateCartProducts(customerId, cartProducts));
        }
        
        [HttpPut("quantity")]
        public async Task<ActionResult<CartProductDto>> UpdateQuantity([FromBody] CartProductDto cartProductDto)
        {
            return Ok(await _cartProductService.UpdateQuantityAsync(cartProductDto.Id, cartProductDto.Quantity));
        }
        
        [HttpDelete("{cartProductId}")]
        public async Task Delete(long cartProductId)
        {
            await _cartProductService.DeleteAsync(cartProductId);
        }
    }
}
