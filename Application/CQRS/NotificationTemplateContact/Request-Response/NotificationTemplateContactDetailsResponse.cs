namespace Application.CQRS.NotificationTemplateContact;

public record NotificationTemplateContactDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? ContactId,
    int? TemplateId,
    DateTime? UpdatedOn
);