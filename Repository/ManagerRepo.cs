using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Repository
{
    public class ManagerRepo : IManager
    {
        private readonly ContextFile _context;
        public ManagerRepo(ContextFile context)
        {
            _context = context;
        }
        public void AddCustomer([FromBody] Customer Users)
        {
            _context.Customer.Add(Users);
            _context.SaveChanges(); 
        }

        public void AddReminderEmail([FromBody] ReminderEmail ReminderEmaill)
        {
            _context.ReminderEmail.Add(ReminderEmaill);
            _context.SaveChanges();
        }

        public void AddVideo([FromBody] VideoCasste VideoCasste)
        {
            _context.VideoCassete.Add(VideoCasste);
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetAllApplicationUser()
        {
            return _context.ApplicationUser;
        }

        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var resultt = _context.Customer.Include(c => c.ApplicationUser).ToList();
            return resultt;
        }

        public IEnumerable<ReminderEmail> GetAllReminderEmailDetails()
        {
            return _context.ReminderEmail;
        }

        public ActionResult<IEnumerable<RentalVideoCasset>> GetAllRentedVideosDetails()
        {
            var resultt = _context.RentalVideoCasset;//.Include(c => c.Customer).Include(c => c.Video).ToList();
            return resultt;

        }

        public IEnumerable<VideoCasste> GetAllVideos()
        {
            return _context.VideoCassete;
        }

        public IEnumerable<ApplicationUser> GetApplicationUserById(int id)
        {
            yield return _context.ApplicationUser.Where(p => p.GenericId == id)
                .FirstOrDefault();
        }
    }
}
