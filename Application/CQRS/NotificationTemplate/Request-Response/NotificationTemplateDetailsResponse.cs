namespace Application.CQRS.NotificationTemplate;

public record NotificationTemplateDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? NotificationTypeId,
    int? LanguageId,
    string? Subject,
    string? SubjectAr,
    string? BodySms,
    string? BodySmsar,
    string? BodyEmail,
    string? BodyEmailAr,
    string? Code,
    string? CodeAr,
    int? DurationInDays
);