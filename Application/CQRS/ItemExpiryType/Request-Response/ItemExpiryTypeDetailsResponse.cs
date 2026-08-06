namespace Application.CQRS.ItemExpiryType;

public record ItemExpiryTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);