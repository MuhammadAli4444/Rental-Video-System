using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class ApplicationUser
    {
        [Key]
        public int GenericId { get; set; }

        [Required(ErrorMessage ="Please Enter your Name")]
        public string? Name { get; set; }
        [Required]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="Please Enter valid email")]
        public string? Email { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
       // [DataType(DataType.PhoneNumber)]
        public string? MobileNumber { get; set; }
        [Required]
        public string ? Role { get; set; }

        
    }
}
