namespace Application.CQRS.RequestLineItemStatus;

public record RequestLineItemStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);