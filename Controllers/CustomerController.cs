using Microsoft.AspNetCore.JsonPatch;
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
        [HttpPost("{id}")]
        public  void ReturnVideo(int id)
        {

            var categoryFromDb = _context.RentalVideoCasset.Find(id);
            RentalVideoCasset simple = new RentalVideoCasset();
            simple.ReturnDate = DateTime.Now;
            simple.Status = "Returned";
            simple.CustomerID = categoryFromDb.CustomerID;
            simple.VideoID = categoryFromDb.VideoID;
            simple.BorrowDate = categoryFromDb.BorrowDate;
            Deletee(id);
      //      _context.RentalVideoCasset.Remove(categoryFromDb);
      //     _context.SaveChanges();


            _context.RentalVideoCasset.Add(simple);
            _context.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void Deletee(int id)
        {
            var categoryFromDb = _context.RentalVideoCasset.Find(id);
            _context.RentalVideoCasset.Remove(categoryFromDb);
            _context.SaveChanges();
        }
    }
}
