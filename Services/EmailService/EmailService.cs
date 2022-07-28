using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public readonly IConfiguration _config;
        private readonly ContextFile _context;
        public string Email { get; set; }
        public EmailService(IConfiguration config, ContextFile context)
        {
            _config = config;
            _context = context;
        }

        public string GetEmail()
        {
            return Email;
        }

        public bool SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            Email= _config.GetSection("EmailUsername").Value;
           

            ApplicationUser Customer = _context.ApplicationUser.Where(s => s.Email== request.To).FirstOrDefault();
              

            if (Customer==null)
            {
                return false;
            }
            RentedVideos CustomerRentedVideo = _context.RentedVideos.Where(s => s.CustomerID == Customer.GenericId ).FirstOrDefault();
            if (CustomerRentedVideo == null)
            {
                return false;
            }
            VideoCollection videoDetails= _context.VideoTable.Find(CustomerRentedVideo.VideoID);
            if (videoDetails == null)
            {
                return false;
            }
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body +
                "Assalam o Alaikum Respected sir, It is reminder to you that you borrow a video from our store on " +
              "<b>" + CustomerRentedVideo.BorrowDate + "</b>" + " and you still did not return the video"+
              "Here are the Details of the video you bought : "+
              "Video Name : "+ videoDetails.TitleName+"<br>"+
              "Video Description : " + videoDetails.Description + "<br>" +
              "Borrow Date : " + CustomerRentedVideo.BorrowDate + "<br>" 
              };


            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
            return true; 
            
        }
    }
}
