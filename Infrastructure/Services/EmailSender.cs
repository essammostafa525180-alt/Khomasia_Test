
using Application.Abstractions;
using Infrastructure.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Services;

public class EmailSender : IEmailSender
{
    private readonly MailSettings _mailSettings;
    private readonly ILogger<EmailSender> _logger;
    private readonly IEmailTemplateService _emailTemplateService;

    public EmailSender(IOptions<MailSettings> mailSettings, ILogger<EmailSender> logger, IEmailTemplateService emailTemplateService)
    {
        _mailSettings = mailSettings.Value;
        _logger = logger;
        _emailTemplateService = emailTemplateService;
    }

    public async Task SendContactMessageEmailAsync(string name, string email, string subject, string message, string? pageUrl)
    {
        string emailBody;
        if (!string.IsNullOrWhiteSpace(pageUrl))
        {
            emailBody = await _emailTemplateService.GetHadithNoteEmailBodyAsync(pageUrl, email, message);
        }
        else
        {
            emailBody = await _emailTemplateService.GetContactUsEmailBodyAsync(name, email, subject, message);
        }

        await SendEmailAsync(email, subject, emailBody);
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        try
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            emailMessage.To.Add(new MailboxAddress(email, email));
            emailMessage.Subject = subject;

            var builder = new BodyBuilder
            {
                HtmlBody = message
            };

            emailMessage.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();



            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(emailMessage);
            await smtp.DisconnectAsync(true);

            _logger.LogInformation("Email sent successfully to {email}", email);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending email to {email}", email);

        }
    }
}
