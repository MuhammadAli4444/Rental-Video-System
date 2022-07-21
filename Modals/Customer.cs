using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }


      
        public ApplicationUser? ApplicationUser { get; set; }
        public ICollection<ReminderEmail>?  ResponseEmail { get; set; }
       
    }
}
