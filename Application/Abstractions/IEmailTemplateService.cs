
namespace Application.Abstractions;

public interface IEmailTemplateService
{
    Task<string> GetContactUsEmailBodyAsync(string name, string email, string subject, string message);
    Task<string> GetHadithNoteEmailBodyAsync(string hadithId, string userEmail, string note);
}
