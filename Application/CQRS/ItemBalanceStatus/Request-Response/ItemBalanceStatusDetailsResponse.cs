namespace Application.CQRS.ItemBalanceStatus;

public record ItemBalanceStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);