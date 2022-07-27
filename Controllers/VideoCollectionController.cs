using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
        public void AddVideo([FromBody] VideoCollection VideoCasste)
        {
                _videocollectionRepo.AddVideo(VideoCasste);
        }
            [HttpGet]

            public IEnumerable<VideoCollection> GetAllVideos()
            {
                return _videocollectionRepo.GetAllVideos();
            }
        }
}
