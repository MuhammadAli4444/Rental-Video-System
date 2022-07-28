using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.DTO_Modals;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]/[action]")]
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
            try { 
                return Ok(_IRentedVideosRepo.GetAllRentedVideosDetails());
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured as because of some internal error", ex);
            }
        }

        [HttpPost]
        public void RentVideo([FromBody] RentedVideoDTOModal RentalVideoCassetObj)
        {
            try
            {
                _IRentedVideosRepo.RentVideo(RentalVideoCassetObj);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured as because of some internal error", ex);
            }
        }
        [HttpPut("{id}")]
        public IActionResult ReturnVideo(int id)
        {
            try
            {
                if (_IRentedVideosRepo.ReturnVideo(id) == 0)
                {
                    return NotFound("Video Already returned");
                }
                else if (_IRentedVideosRepo.ReturnVideo(id) == 1)
                {
                    return Ok("Video has been successfully returned");
                }
                else
                {
                    return NotFound("Video not exist in the Rented Videos Collection");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured as because of some internal error", ex);
            }
        }

    }
}
