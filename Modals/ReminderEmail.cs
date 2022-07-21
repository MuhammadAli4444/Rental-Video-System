using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class ReminderEmail
    {
        [Key]
        public int Id { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime BorrowDate { get; set; }
        public String? Subject { get; set; }
        public String? Message { get; set; }
        public int? CustomerId { get; set; }
    }
}
