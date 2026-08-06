namespace Application.CQRS.NotificationPlaceHolder;

public record NotificationPlaceHolderDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr,
    string? Value
);