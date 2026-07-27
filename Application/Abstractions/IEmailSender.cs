
namespace Application.Abstractions;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
    Task SendContactMessageEmailAsync(string name, string email, string subject, string message, string? pageUrl);
}
