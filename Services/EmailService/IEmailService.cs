using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Services.EmailService
{
    public interface IEmailService
    {
        bool SendEmail(EmailDto request);
        string GetEmail();
    }
}
