using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedVideosController : ControllerBase
    {
        private readonly IRentedVideos _IRentedVideosRepo;
        public RentedVideosController(IRentedVideos rentedvideoRepo)
        {
            _IRentedVideosRepo = rentedvideoRepo;
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
            var categoryFromDb = _IRentedVideosRepo.GetVideoData(id);
            RentedVideos simple = new RentedVideos();
            simple.ReturnDate = DateTime.Now;
            simple.Status = "Returned";
            simple.CustomerID = categoryFromDb.CustomerID;
            simple.VideoID = categoryFromDb.VideoID;
            simple.BorrowDate = categoryFromDb.BorrowDate;
            _IRentedVideosRepo.ReturnVideo(simple);
        }

    }
}
