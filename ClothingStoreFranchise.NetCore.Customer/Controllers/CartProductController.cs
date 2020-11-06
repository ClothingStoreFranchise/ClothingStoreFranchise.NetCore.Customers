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

        [HttpGet]
        public async Task<ActionResult<ICollection<CartProductDto>>> GetWithoutLogIn(ICollection<CartProductDto> cartProductDtos)
        {
            return Ok(await _stockService.FindByProductIdAndSizeWithEnoughStock(cartProductDtos));
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<ICollection<CartProductDto>>> GetByUsername(string username)
        {
            return Ok(await _cartProductService.FindCartProductsByUsername(username));
        }

        [HttpPost]
        public async Task<ActionResult<ICollection<CartProductDto>>> Create(ICollection<CartProductDto> cartProductDtos)
        {
            return Ok(await _cartProductService.CreateAsync(cartProductDtos));
        }

        [HttpPut]
        public async Task<ActionResult<CartProductDto>> Update(CartProductDto cartProductDto)
        {
            return Ok(await _cartProductService.UpdateAsync(cartProductDto));
        }

        [HttpDelete("{cartProductId}")]
        public async Task Delete(long cartProductId)
        {
            await _cartProductService.DeleteAsync(new List<long>() { cartProductId });
        }
    }
}
