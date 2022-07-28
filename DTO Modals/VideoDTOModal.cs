using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.DTO_Modals
{
    public class VideoDTOModal
    {

        [Required]
        public string? TitleName { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Range(10, 10000, ErrorMessage = "Please Enter price in between 1 to 10000")]
        public int Price { get; set; }
    }
}
