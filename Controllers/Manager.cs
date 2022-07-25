using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalVideoSystem.Modals;
using RentalVideoSystem.Repository;
using restapipractise.Data;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Manager : Controller
    {
        private readonly ContextFile _context;
        public Manager(ContextFile context)
        {
            _context = context;
        }
        [HttpGet("{id}")]

        public IEnumerable<ApplicationUser> GetApplicationUserById(int id)
        {
            yield return _context.ApplicationUser.Where(p => p.GenericId == id)
                .FirstOrDefault();
        }
        [HttpGet]

        public IEnumerable<ApplicationUser> GetAllApplicationUser()
        {
            return _context.ApplicationUser;
        }
        [HttpGet]

        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var resultt = _context.Customer.Include(c => c.ApplicationUser).ToList();
            return Ok(resultt);
        }
        [HttpGet]

        public IEnumerable<VideoCasste> GetAllVideos()
        {
            return _context.VideoCassete;
        }
        [HttpGet]

        public IEnumerable<ReminderEmail> GetAllReminderEmailDetails()
        {
            return _context.ReminderEmail;
        }
        //---------------------------------------------------------------------
        [HttpPost]
        public void AddCustomer([FromBody] Customer Users )
        {
            _context.Customer.Add(Users);
          //  _context.Customer.Add(Users);
            _context.SaveChanges();
        }
        [HttpPost]
        public void AddReminderEmail([FromBody] ReminderEmail ReminderEmaill)
        {
            _context.ReminderEmail.Add(ReminderEmaill);
            //  _context.Customer.Add(Users);
            _context.SaveChanges();
        }
        [HttpPost]
        public void AddVideo([FromBody] VideoCasste VideoCasste)
        {
            _context.VideoCassete.Add(VideoCasste);
            //  _context.Customer.Add(Users);
            _context.SaveChanges();
        }
    }
}
