using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Interfaces;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUser _ApplicationUserRepo;
        public ApplicationUserController(IApplicationUser managerRepo)
        {
            _ApplicationUserRepo = managerRepo;
        }
        [HttpGet]

        public ActionResult<IEnumerable<ApplicationUserController>> GetAllApplicationUser()
        {
            return Ok(_ApplicationUserRepo.GetAllApplicationUser());
        }
    // [HttpGet("{id}")]

     //  public ActionResult<IEnumerable<ApplicationUserController>> GetApplicationUserById(int id)
      // {
     //      return _ApplicationUserRepo.GetApplicationUserById(id);



      // }
    }
}
