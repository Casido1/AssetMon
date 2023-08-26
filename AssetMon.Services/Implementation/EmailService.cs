using AssetMon.Models.ConfigurationModels;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace AssetMon.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly MailConfiguration _mailConfiguration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _mailConfiguration = new MailConfiguration();
            _configuration.Bind(_mailConfiguration.Section, _mailConfiguration);
        }

        public async Task SendMailAsync(EmailDTO emailDTO)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailConfiguration.UserName));
            email.To.Add(MailboxAddress.Parse(emailDTO.To));
            email.Subject = emailDTO.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailDTO.Body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_mailConfiguration.Host, 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailConfiguration.UserName, _mailConfiguration.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
