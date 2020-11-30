using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Facade;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            return "Hola";
        }*/


        //[Authorize(Roles = Policies.Admin)]
        [HttpGet("{username}")]
        public async Task<ActionResult<CustomerDto>> GetByUsername(string username)
        {
            return await _customerService.FindByUsernameAsync(username);
        }

        [HttpPost]
        public async Task<ActionResult<CartProductDto>> Create(CustomerDto customer)
        {
            return Ok(await _customerService.CreateAsync(customer));
        }

        /*
        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
