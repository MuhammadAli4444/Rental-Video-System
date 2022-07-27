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

        public void ReturnVideo(int id)
        {
            var categoryFromDb = _context.RentedVideos.Find(id);
            RentedVideos simple = new RentedVideos();
            simple.ReturnDate = DateTime.Now;
            simple.Status = "Returned";
            simple.CustomerID = categoryFromDb.CustomerID;
            simple.VideoID = categoryFromDb.VideoID;
            simple.BorrowDate = categoryFromDb.BorrowDate;
            _context.RentedVideos.Add(simple);
            _context.SaveChanges();
        }
    }
}
