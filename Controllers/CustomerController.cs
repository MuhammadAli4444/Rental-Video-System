using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Modals;
using RentalVideoSystem.Repository;
using restapipractise.Data;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ContextFile _context;
        public CustomerController(ContextFile context)
        {
            _context = context;
        }
  
        [HttpGet]

        public IEnumerable<VideoCasste> GetAllVideos()
        {
            return _context.VideoCassete;
        }
        [HttpPost]
        public void AddVideo([FromBody] Customer Users)
        {
            _context.Customer.Add(Users);
            //  _context.Customer.Add(Users);
            _context.SaveChanges();
        }
    }
}
