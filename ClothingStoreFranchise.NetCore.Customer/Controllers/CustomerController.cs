using ClothingStoreFranchise.NetCore.Common.Constants;
using ClothingStoreFranchise.NetCore.Common.Security;
using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        /*[HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public string Get()
        {        //public IEnumerable<Customer> Get()

            string a = HttpContext.User.Identity.Name;
            if (!HttpContext.User.Identity.IsAuthenticated)
                a = "fail";
            //return db.Customer.ToList();
            return "fff";
        }*/


        [HttpGet("{username}")]
        [Authorize(Roles = Role.Customer)]
        public async Task<ActionResult<CustomerDto>> GetByUsername(string username)
        {
            return await _customerService.FindByUsernameAsync(username);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<CartProductDto>> Create([FromBody] CustomerDto customer)
        {
            return Created("customers", await _customerService.CreateAsync(customer));
        }

        [HttpPut]
        [Authorize(Roles = Role.Customer)]
        public async Task<ActionResult<CartProductDto>> Update([FromBody] CustomerDto customer)
        {
            return Ok(await _customerService.UpdateAsync(customer));
        }

        [HttpPut("checkout")]
        [Authorize(Roles = Role.Customer)]
        public async Task<ActionResult<CartProductDto>> UpdateAfterCheckout([FromBody] CustomerDto customer)
        {
            return Ok(await _customerService.UpdateCustomerAfterCheckoutAsync(customer));
        }
    }
}
