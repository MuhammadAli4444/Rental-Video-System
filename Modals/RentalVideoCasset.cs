namespace RentalVideoSystem.Modals
{
    public class VideoCassete
    {
        public int Id { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? BorrowDate { get; set; } = DateTime.Now;
        public Customer? CustomerID { get; set; }
        public VideoCasste? VideoID { get; set; }
        public bool Status { get; set; }






    }
}
