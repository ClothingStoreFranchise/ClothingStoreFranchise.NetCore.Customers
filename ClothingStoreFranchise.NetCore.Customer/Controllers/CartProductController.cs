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

        public CartProductController(ICartProductService cartProductService)
        {
            _cartProductService = cartProductService;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<ICollection<CartProductDto>>> Get(string username)
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
        public async Task delete(long cartProductId)
        {
            await _cartProductService.DeleteAsync(new List<long>() { cartProductId });
        }
    }
}
