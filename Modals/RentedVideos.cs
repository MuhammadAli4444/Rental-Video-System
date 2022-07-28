﻿namespace RentalVideoSystem.Modals
{
    public class RentedVideos
    {
        public int Id { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? BorrowDate { get; set; } = DateTime.Now;
       public int CustomerID { get; set; }
       
        public int VideoID { get; set; }
        public string? Status { get; set; } = "Not Returned";

        
        //  public VideoCasste Video { get; set; }




    }
}
