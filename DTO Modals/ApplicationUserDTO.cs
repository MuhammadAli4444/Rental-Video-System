using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.DTO_Modals
{
    public class ApplicationUserDTO
    {
 

  

        [Required(ErrorMessage = "Please Enter your Name")]
        public string? Name { get; set; } = string.Empty;
        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please Enter valid email")]
        public string? Email { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        // [DataType(DataType.PhoneNumber)]
        public string? MobileNumber { get; set; }



        public string Password { get; set; } = string.Empty;
    }
    
}
