using RentalVideoSystem.DTO_Modals;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Repository
{
    public class RentedVideosRepo : IRentedVideos
    {
        private readonly ContextFile _context;
        public RentedVideosRepo(ContextFile context)
        {
            _context = context;
        }



        IEnumerable<RentedVideos> IRentedVideos.GetAllRentedVideosDetails()
        {
            var resultt = _context.RentedVideos;//.Include(c => c.Customer).Include(c => c.Video).ToList();
            return resultt;
        }

        public void RentVideo(RentedVideoDTOModal Object )
        {
            RentedVideos RentalVideoCassetObj=new RentedVideos();
            RentalVideoCassetObj.VideoID = Object.VideoID;
            RentalVideoCassetObj.BorrowDate = DateTime.Now;
            RentalVideoCassetObj.Status = "Not Returned";
            RentalVideoCassetObj.CustomerID = Object.CustomerID;
           _context.RentedVideos.Add(RentalVideoCassetObj);
            _context.SaveChanges();
        }

        public void ReturnVideo(RentedVideos simple)
        {

            _context.RentedVideos.Add(simple);
            _context.SaveChanges();
        }
        public int ReturnVideo(int id)
        {
          RentedVideos RentedVideo= _context.RentedVideos.Find(id);
           if(RentedVideo==null)
            {
                return -1;
            }
            else
            {
                if (RentedVideo.Status == "Not Returned")
                {
                    RentedVideo.Status = "Returned";
                    RentedVideo.ReturnDate = DateTime.Now;
                    _context.Update(RentedVideo);
                    _context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
        }
    }
}
