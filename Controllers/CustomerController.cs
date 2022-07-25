using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Modals;

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
        public void RentVideo([FromBody] RentalVideoCasset RentalVideoCassetObj)
        {
            _context.RentalVideoCasset.Add(RentalVideoCassetObj);
            //  _context.Customer.Add(Users);
            _context.SaveChanges();
        }
    }
}
