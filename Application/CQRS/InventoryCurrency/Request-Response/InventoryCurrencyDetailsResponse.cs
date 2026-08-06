namespace Application.CQRS.InventoryCurrency;

public record InventoryCurrencyDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);