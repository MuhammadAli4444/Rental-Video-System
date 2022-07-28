using RentalVideoSystem.DTO_Modals;
using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Interfaces
{
    public interface IVideoCollection
    {
        public IEnumerable<VideoCollection> GetAllVideos();
        public bool AddVideo(VideoDTOModal Obj);

    }
}
