namespace Application.CQRS.InventoryItemTrasnsactionType;

public record InventoryItemTrasnsactionTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);