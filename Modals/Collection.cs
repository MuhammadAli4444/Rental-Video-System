using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class Collection
    {
        [Key]
        public int CollectionId { get; set; }
        //public int VideoId { get; set; }
        //public IEnumerable<VideoCasste> Videos{ get;set;}
       
        public int ManagerId { get; set; }

        public Manager Manager { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
