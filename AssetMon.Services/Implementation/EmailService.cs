using AssetMon.Models.ConfigurationModels;
using AssetMon.Services.Interface;
using AssetMon.Services.TemplateEngine;
using AssetMon.Shared.DTOs;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace AssetMon.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly ITemplateEngine _templateEngine;
        private readonly IConfiguration _configuration;
        private readonly MailConfiguration _mailConfiguration;

        public EmailService(IConfiguration configuration, ITemplateEngine templateEngine)
        {
            _templateEngine = templateEngine;
            _configuration = configuration;
            _mailConfiguration = new MailConfiguration();
            _configuration.Bind(_mailConfiguration.Section, _mailConfiguration);
        }

        public async Task SendMailAsync(string emailTo, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailConfiguration.UserName));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_mailConfiguration.Host, 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailConfiguration.UserName, _mailConfiguration.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendPasswordResetEmail(EmailOptions emailOptions)
        {
            string subject = "Password Reset";

            var emailBody = await _templateEngine.GenerateBodyHtml("PasswordResetEmail", emailOptions.PlaceHolder);

            await SendMailAsync("ophelia.sawayn@ethereal.email", subject, emailBody);
        }
    }
}
