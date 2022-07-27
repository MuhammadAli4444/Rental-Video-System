using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Repository
{
    public class VideoCollectionRepo : IVideoCollection
    {
        private readonly ContextFile _context;
        public VideoCollectionRepo(ContextFile context)
        {
            _context = context;
        }

        public IEnumerable<VideoCollection> GetAllVideos()
        {
            return _context.VideoTable;
        }


        public void AddVideo(VideoCollection VideoCasste)
        {
            _context.VideoTable.Add((VideoCollection)VideoCasste);
            _context.SaveChanges();
        }
    }
}
