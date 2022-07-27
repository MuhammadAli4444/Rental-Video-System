using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
