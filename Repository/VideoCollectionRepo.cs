using RentalVideoSystem.DTO_Modals;
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


        public bool AddVideo(VideoDTOModal Obj)
        {
    
            var video = _context.VideoTable.Where(x => x.TitleName.Contains(Obj.TitleName)).ToList();
       
            if (video != null)
            {
                VideoCollection VideoCasste = new VideoCollection();
                VideoCasste.TitleName = Obj.TitleName;
                VideoCasste.Price = Obj.Price;
                VideoCasste.Description = Obj.Description;
                _context.VideoTable.Add((VideoCollection)VideoCasste);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
