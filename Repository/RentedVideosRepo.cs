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

        public void RentVideo(RentedVideos RentalVideoCassetObj)
        {
            _context.RentedVideos.Add(RentalVideoCassetObj);
            _context.SaveChanges();
        }

        public void ReturnVideo(RentedVideos simple)
        {

            _context.RentedVideos.Add(simple);
            _context.SaveChanges();
        }
        public RentedVideos GetVideoData(int id)
        {
        return  _context.RentedVideos.Find(id);
        }
    }
}
