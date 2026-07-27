
using Application.Abstractions;


namespace Infrastructure.Services;
public class EmailTemplateService : IEmailTemplateService
{
    public EmailTemplateService()
    {
    }

    public async Task<string> GetContactUsEmailBodyAsync(string name, string email, string subject, string message)
    {
        var templatePath = Path.Combine(AppContext.BaseDirectory, "Templates", "Email", "ContactUs.html");

        if (!File.Exists(templatePath))
        {
            // Fallback or throw
            throw new FileNotFoundException($"Template not found at {templatePath}");
        }

        var template = await File.ReadAllTextAsync(templatePath);

        return template
            .Replace("{{Name}}", name)
            .Replace("{{Email}}", email)
            .Replace("{{Subject}}", subject)
            .Replace("{{Message}}", message)
            .Replace("{{Year}}", DateTime.Now.Year.ToString());
    }

    public async Task<string> GetHadithNoteEmailBodyAsync(string hadithUrl, string userEmail, string note)
    {
        var templatePath = Path.Combine(AppContext.BaseDirectory, "Templates", "Email", "HadithNote.html");

        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException($"Template not found at {templatePath}");
        }

        var template = await File.ReadAllTextAsync(templatePath);

        return template
            .Replace("{{HadithUrl}}", hadithUrl)
            .Replace("{{UserEmail}}", userEmail)
            .Replace("{{Note}}", note)
            .Replace("{{Year}}", DateTime.Now.Year.ToString());
    }
}
