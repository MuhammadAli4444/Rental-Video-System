using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class VideoCasste
    {
        [Key]
        public int VideoId { get; set; }
        [Required]
        public string? TitleName { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Range(10,10000,ErrorMessage ="Please Enter price in between 1 to 10000")]
        public int Price { get; set; }
      
      
    }
}

