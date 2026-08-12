using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.NotificationAggregate
{
    public class NotificationTemplate : AggregateRootEntityBase<int>
    {
        public int? NotificationTypeId { get; set; }
        public int? LanguageId { get; set; }
        public string? Subject { get; set; }
        public string? SubjectAr { get; set; }
        public string? BodySms { get; set; }
        public string? BodySmsar { get; set; }
        public string? BodyEmail { get; set; }
        public string? BodyEmailAr { get; set; }
        public string? Code { get; set; }
        public string? CodeAr { get; set; }
        public int? DurationInDays { get; set; }
        public Language? Language { get; set; }
        public NotificationType? NotificationType { get; set; }

        private List<NotificationTemplateContact> _notificationTemplateContacts = new List<NotificationTemplateContact>();
        public IReadOnlyCollection<NotificationTemplateContact> NotificationTemplateContacts => _notificationTemplateContacts;

        public NotificationTemplate()
        {
        }

        public NotificationTemplate(int? notificationTypeId, int? languageId, string? subject, string? subjectAr, string? bodySms, string? bodySmsar, string? bodyEmail, string? bodyEmailAr, string? code, string? codeAr, int? durationInDays, bool isActive) : this()
        {
            NotificationTypeId = notificationTypeId;
            LanguageId = languageId;
            Subject = subject;
            SubjectAr = subjectAr;
            BodySms = bodySms;
            BodySmsar = bodySmsar;
            BodyEmail = bodyEmail;
            BodyEmailAr = bodyEmailAr;
            Code = code;
            CodeAr = codeAr;
            DurationInDays = durationInDays;
            IsActive = isActive;
        }

        public static NotificationTemplate Create(int? notificationTypeId, int? languageId, string? subject, string? subjectAr, string? bodySms, string? bodySmsar, string? bodyEmail, string? bodyEmailAr, string? code, string? codeAr, int? durationInDays, bool isActive)
        {

            return new NotificationTemplate(notificationTypeId, languageId, subject, subjectAr, bodySms, bodySmsar, bodyEmail, bodyEmailAr, code, codeAr, durationInDays, isActive);
        }

        public void Update(int? notificationTypeId, int? languageId, string? subject, string? subjectAr, string? bodySms, string? bodySmsar, string? bodyEmail, string? bodyEmailAr, string? code, string? codeAr, int? durationInDays, bool isActive)
        {
            NotificationTypeId = notificationTypeId;
            LanguageId = languageId;
            Subject = subject;
            SubjectAr = subjectAr;
            BodySms = bodySms;
            BodySmsar = bodySmsar;
            BodyEmail = bodyEmail;
            BodyEmailAr = bodyEmailAr;
            Code = code;
            CodeAr = codeAr;
            DurationInDays = durationInDays;
            IsActive = isActive;
        }
    }
}
