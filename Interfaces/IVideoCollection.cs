using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Interfaces
{
    public interface IVideoCollection
    {
        public IEnumerable<VideoCollection> GetAllVideos();
        public void AddVideo(VideoCollection VideoCasste);

    }
}
