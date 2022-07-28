using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ContextFile _context;
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService, ContextFile context)
        {
           _emailService = emailService;
            _context = context;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            try { 
                if(request == null)
                {
                    return BadRequest("No body received");
                }

                else
                {

                   if(_emailService.SendEmail(request))
                    {
                        return Ok("Email successfully sent to the customer");
                    }
                    else
                    {
                        return NotFound("Email do not exist in the record");
                    }
                        
                   
                }
                 }
            catch (Exception ex)
            {
                throw new Exception("Exception occured as because of some internal error", ex);
            }
        }

    }
}
