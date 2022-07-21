namespace RentalVideoSystem.Modals
{
    public class BorrowedItems
    {
        public int Id { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? BorrowDate { get; set; }
        public Customer? CustomerID { get; set; }
        public VideoCasste? VideoID { get; set; }
        public bool Status { get; set; }






    }
}
