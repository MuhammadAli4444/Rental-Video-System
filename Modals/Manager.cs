using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class Manager
    {

        [Key]
        public int ManagerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        public string MobileNumber { get; set; }

        //public int CollectionId { get; set; }
        public Collection Collection { get; set; }
        //    public IEnumerable<Customer> customers { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
