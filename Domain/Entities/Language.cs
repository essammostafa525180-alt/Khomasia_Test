using Domain.Aggregates.NotificationAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Language : AuditableEntityBase<int>
    {
        public string? LanguageName { get; private set; }
        public string? LanguageNameAr { get; private set; }

        private List<NotificationTemplate> _notificationTemplates = new List<NotificationTemplate>();
        public IReadOnlyCollection<NotificationTemplate> NotificationTemplates => _notificationTemplates;

        private Language()
        {
        }

        public Language(string? languageName, string? languageNameAr, bool isActive) : this()
        {
            LanguageName = languageName;
            LanguageNameAr = languageNameAr;
            IsActive = isActive;
        }

        public static Language Create(string? languageName, string? languageNameAr, bool isActive)
        {

            return new Language(languageName, languageNameAr, isActive);
        }

        public void Update(string? languageName, string? languageNameAr, bool isActive)
        {
            LanguageName = languageName;
            LanguageNameAr = languageNameAr;
            IsActive = isActive;
        }
    }
}
