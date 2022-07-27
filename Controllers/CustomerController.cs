using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepo;
        public CustomerController(ICustomer customerRepo)
        {
            _customerRepo = customerRepo;
        }
        [HttpGet]

        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return _customerRepo.GetAllCustomers();
        }
        [HttpPost]
        public void AddCustomer([FromBody] Customer Users)
        {
            _customerRepo.AddCustomer(Users);
        }

    }
}
