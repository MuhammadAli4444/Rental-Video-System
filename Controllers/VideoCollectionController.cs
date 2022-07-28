using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.DTO_Modals;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;
namespace RentalVideoSystem.Controllers
{
  
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class VideoCollectionController : ControllerBase
    {
            private readonly IVideoCollection _videocollectionRepo;
            public VideoCollectionController(IVideoCollection videoRepo)
            {
                _videocollectionRepo = videoRepo;
            }


        [HttpPost]
        public IActionResult AddVideo([FromBody] VideoDTOModal Obj)
        {
            try { 

            if (_videocollectionRepo.AddVideo(Obj))
            {
                return Ok("Video has been succesffuly added");
            }
            else
            {
                return NotFound("Video already exist in the collection");
            }
        }catch (Exception ex)
            {
                throw new Exception("Exception occured as because of some internal error", ex);
    }
}
        [HttpGet]

        public IEnumerable<VideoCollection> GetAllVideos()
        {
            try { 
            return _videocollectionRepo.GetAllVideos();
        }
            catch (Exception ex)
            {
                throw new Exception("Exception occured as because of some internal error", ex);
            }
        }
        }
}
