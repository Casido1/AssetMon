using AssetMon.Models.ConfigurationModels;
using AssetMon.Services.Interface;
using AssetMon.Services.TemplateEngine;
using AssetMon.Shared.DTOs;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace AssetMon.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly ITemplateEngine _templateEngine;
        private readonly IOptions<MailConfiguration> _mailConfiguration;

        public EmailService(ITemplateEngine templateEngine, IOptions<MailConfiguration> mailConfiguration)
        {
            _templateEngine = templateEngine;
            _mailConfiguration = mailConfiguration;
        }

        public async Task SendMailAsync(string emailTo, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailConfiguration.Value.UserName));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_mailConfiguration.Value.SmtpServer, _mailConfiguration.Value.Port, true);
            smtp.AuthenticationMechanisms.Remove("XOAUTH2");
            await smtp.AuthenticateAsync(_mailConfiguration.Value.UserName, _mailConfiguration.Value.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendPasswordResetEmailAsync(EmailOptions emailOptions, string emailTo)
        {
            string subject = "Password Reset";

            var emailBody = await _templateEngine.GenerateBodyHtml("PasswordResetEmail", emailOptions.PlaceHolder);

            await SendMailAsync(emailTo, subject, emailBody);
        }

        public async Task SendEmailConfirmationMailAsync(EmailOptions emailOptions, string emailTo)
        {
            string subject = "Email Confirmation";

            var emailBody = await _templateEngine.GenerateBodyHtml("EmailConfirmationMail", emailOptions.PlaceHolder);

            await SendMailAsync(emailTo, subject, emailBody);
        }
    }
}
