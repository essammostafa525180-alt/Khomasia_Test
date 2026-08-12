namespace Application.CQRS.NotificationState;

public record NotificationStateDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? StatusName,
    string? StatusNameAr
);