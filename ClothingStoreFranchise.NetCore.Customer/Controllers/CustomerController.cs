using ClothingStoreFranchise.NetCore.Customers.Dto;
using ClothingStoreFranchise.NetCore.Customers.Facade;
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
            return Created("customers", await _customerService.CreateAsync(customer));
        }
    }
}
