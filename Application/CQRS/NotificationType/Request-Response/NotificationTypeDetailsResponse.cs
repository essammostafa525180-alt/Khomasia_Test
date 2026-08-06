namespace Application.CQRS.NotificationType;

public record NotificationTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? NotificationTypeEn,
    string? NotificationTypeAr
);