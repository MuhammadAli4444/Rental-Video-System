using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Interfaces
{
    public interface IManager
    {
        public IEnumerable<ApplicationUser> GetApplicationUserById(int id);
        public IEnumerable<ApplicationUser> GetAllApplicationUser();
        public ActionResult<IEnumerable<Customer>> GetAllCustomers();
        public IEnumerable<VideoCasste> GetAllVideos();
        public IEnumerable<ReminderEmail> GetAllReminderEmailDetails();
        public ActionResult<IEnumerable<RentalVideoCasset>> GetAllRentedVideosDetails();
        public void AddCustomer([FromBody] Customer Users);
        public void AddReminderEmail([FromBody] ReminderEmail ReminderEmaill);
        public void AddVideo([FromBody] VideoCasste VideoCasste);

    }
}
