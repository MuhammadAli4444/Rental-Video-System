using RentalVideoSystem.DTO_Modals;
using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Interfaces
{
    public interface IRentedVideos
    {
        public IEnumerable<RentedVideos> GetAllRentedVideosDetails();
        public void RentVideo(RentedVideoDTOModal Object);

        public int ReturnVideo(int id);
    }
}
