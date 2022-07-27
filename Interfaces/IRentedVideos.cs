using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Interfaces
{
    public interface IRentedVideos
    {
        public IEnumerable<RentedVideos> GetAllRentedVideosDetails();
        public void RentVideo(RentedVideos RentalVideoCassetObj);
public void ReturnVideo(int id);
    }
}
