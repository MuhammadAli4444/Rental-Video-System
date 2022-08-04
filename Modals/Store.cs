using RentalVideoSystem.DTO_Modals;
using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        public ICollection<ApplicationUser> ApplicationUser { get; set; }

        public Manager? Manager_Obj { get; set; }
    
        public ICollection<VideoCollection> VideoCollection{ get; set; }
    }
}