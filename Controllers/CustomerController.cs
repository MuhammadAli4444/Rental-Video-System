using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.DTO_Modals;
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

        public ActionResult<IEnumerable<CustomerDTOModal>> GetAllCustomers()
        {
            try
            {
                return _customerRepo.GetAllCustomers();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured as because of some internal error", ex);
            }
   
        }
        [HttpPost]
        public IActionResult AddCustomer([FromBody]CustomerDTOModal Users)
        {
            try
            {
                if (_customerRepo.AddCustomer(Users))
            {
                return Ok("Customer has been succesffuly added in the system");
            }
            else
            {
                return BadRequest("Record is not added");
            }
        }
            catch (Exception ex)
            {
                throw new Exception("Exception occured as because of some internal error", ex);
    }
}

    }
}
