using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class ApplicationUser
    {
        [Key]
        public int GenericId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public string? Email { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        public string? MobileNumber { get; set; }
        [Required]
        public string ? Role { get; set; }
    }
}
