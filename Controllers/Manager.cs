using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Modals;
using RentalVideoSystem.Repository;
using restapipractise.Data;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Manager:Controller
    {
        private readonly ContextFile _context;
        public Manager(ContextFile context)
        {
            _context= context;
        }
        [HttpGet]
        //  [ProducesResponseType(200,Type=typeof(IEnumerable<Manager>))]
        //   public IActionResult GetCustomers()
        //   {
        //       var results = _managerRepository.GetCustomers();
        //       if(!ModelState.IsValid)
        //       {
        //           return BadRequest(ModelState);
        //      }
        //      return Ok(results);
        //  }
        public IEnumerable<ApplicationUser> Get()
        {
            return _context.ApplicationUser;
        }
    }
}
