using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedVideosController : ControllerBase
    {
        private readonly IRentedVideos _IRentedVideosRepo;
        public RentedVideosController(IRentedVideos managerRepo)
        {
            _IRentedVideosRepo = managerRepo;
        }


        [HttpGet]

        public ActionResult<IEnumerable<VideoCollection>> GetAllRentedVideosDetails()
        {

            return Ok(_IRentedVideosRepo.GetAllRentedVideosDetails());
        }
        [HttpPost]
        public void RentVideo([FromBody] RentedVideos RentalVideoCassetObj)
        {
            _IRentedVideosRepo.RentVideo(RentalVideoCassetObj);
        }
        [HttpPost("{id}")]
        public void ReturnVideo(int id)
        {
            _IRentedVideosRepo.ReturnVideo(id);
        }

    }
}
