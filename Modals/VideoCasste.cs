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
        public int Price { get; set; }
      
      
    }
}

