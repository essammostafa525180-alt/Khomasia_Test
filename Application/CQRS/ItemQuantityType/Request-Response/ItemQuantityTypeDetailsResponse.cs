namespace Application.CQRS.ItemQuantityType;

public record ItemQuantityTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);