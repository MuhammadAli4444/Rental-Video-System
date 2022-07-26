using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomer _customerRepo;
        public CustomerController(ICustomer customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]

        public IEnumerable<VideoCasste> GetAllVideos()
        {
            return _customerRepo.GetAllVideos();
        }
        [HttpPost]
        public void RentVideo([FromBody] RentalVideoCasset RentalVideoCassetObj)
        {
           _customerRepo.RentVideo(RentalVideoCassetObj);
        }
        [HttpPost("{id}")]
        public  void ReturnVideo(int id)
        {
            _customerRepo.ReturnVideo(id);
        }
        [HttpDelete("{id}")]
        public void Deletee(int id)
        {
            _customerRepo.Deletee(id);
        }
    }
}
