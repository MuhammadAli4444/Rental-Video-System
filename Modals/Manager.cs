using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class Manager
    {

        [Key]
        public int Id { get; set; }
        
        public ApplicationUser? ApplicationUser { get; set; }

    

    }
}
