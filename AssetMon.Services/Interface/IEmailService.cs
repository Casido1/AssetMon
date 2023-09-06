using AssetMon.Shared.DTOs;

namespace AssetMon.Services.Interface
{
    public interface IEmailService
    {
        Task SendMailAsync(string emailTo, string subject, string body);
        Task SendPasswordResetEmailAsync(EmailOptions emailOptions, string emailTo);
        Task SendEmailConfirmationMailAsync(EmailOptions emailOptions, string emailTo);
    }
}
