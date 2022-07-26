using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Manager : Controller
    {
        private readonly IManager _managerRepo;
        public Manager(IManager managerRepo)
        {
              _managerRepo = managerRepo;
        }
        [HttpGet("{id}")]

        public ActionResult<IEnumerable<ApplicationUser>> GetApplicationUserById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Id Entered");
            }
            return Ok(ModelState);

    
          
        }
        [HttpGet]

        public IEnumerable<ApplicationUser> GetAllApplicationUser()
        {
           return _managerRepo.GetAllApplicationUser();
        }
        [HttpGet]

        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return _managerRepo.GetAllCustomers();
        }
        [HttpGet]

        public IEnumerable<VideoCasste> GetAllVideos()
        {
            return _managerRepo.GetAllVideos();
        }
        [HttpGet]

        public IEnumerable<ReminderEmail> GetAllReminderEmailDetails()
        {
            return _managerRepo.GetAllReminderEmailDetails();
        }
        [HttpGet]

        public ActionResult<IEnumerable<RentalVideoCasset>> GetAllRentedVideosDetails()
        {

            return Ok(_managerRepo.GetAllRentedVideosDetails());
        }
        //---------------------------------------------------------------------
        [HttpPost]
        public void AddCustomer([FromBody] Customer Users )
        {
            _managerRepo.AddCustomer(Users);
        }
        [HttpPost]
        public void AddReminderEmail([FromBody] ReminderEmail ReminderEmaill)
        {
             _managerRepo.AddReminderEmail(ReminderEmaill);
        }
        [HttpPost]
        public void AddVideo([FromBody] VideoCasste VideoCasste)
        {
            _managerRepo.AddVideo(VideoCasste);
        }
       
    }
}
