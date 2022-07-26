using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Repository
{

    public class CustomerRepo : ICustomer
    {
        private readonly ContextFile _context;
        public CustomerRepo(ContextFile context)
        {
            _context = context;
        }
        public void Deletee(int id)
        {
            var categoryFromDb = _context.RentalVideoCasset.Find(id);
            _context.RentalVideoCasset.Remove(categoryFromDb);
            _context.SaveChanges();
        }

        public IEnumerable<VideoCasste> GetAllVideos()
        {
            return _context.VideoCassete;
        }

        public void RentVideo([FromBody] RentalVideoCasset RentalVideoCassetObj)
        {
            _context.RentalVideoCasset.Add(RentalVideoCassetObj);
            _context.SaveChanges();
        }

        public void ReturnVideo(int id)
        {
            var categoryFromDb = _context.RentalVideoCasset.Find(id);
            RentalVideoCasset simple = new RentalVideoCasset();
            simple.ReturnDate = DateTime.Now;
            simple.Status = "Returned";
            simple.CustomerID = categoryFromDb.CustomerID;
            simple.VideoID = categoryFromDb.VideoID;
            simple.BorrowDate = categoryFromDb.BorrowDate;
            _context.RentalVideoCasset.Add(simple);
            _context.SaveChanges();
        }
    }
}
