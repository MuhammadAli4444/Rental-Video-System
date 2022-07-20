using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class VideoCasste
    {
        [Key]
        public int VideoId { get; set; }
        [Required]
        public string TitleName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int Price { get; set; }
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
        public Customer CustomerID { get; set; }
        public Customer Customer { get; set; }
       // public bool Status { get; set; }
        //public int Copies { get; set; }
    }
}

