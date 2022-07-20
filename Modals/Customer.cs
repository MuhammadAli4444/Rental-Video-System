using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
      
        public string Email { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        public string MobileNumber { get; set; }
      

        public IDictionary<int, string> Responses = new Dictionary<int, string>();
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
