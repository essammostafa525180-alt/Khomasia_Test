namespace Application.CQRS.Notification;

public record NotificationDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? To,
    string? Cc,
    string? Bcc,
    string? PhoneNumber,
    string? Subject,
    string? Body,
    int? StatusId,
    DateTime? CreateDate,
    DateTime? LastUpdateDate,
    DateTime? SendDate,
    int? NotificationTypeId,
    string? NotificationSource,
    string? ErrorMessage,
    int? SendTries,
    DateTime? NotificationDateTime,
    byte[]? Attachment,
    string? AttachmentType
);