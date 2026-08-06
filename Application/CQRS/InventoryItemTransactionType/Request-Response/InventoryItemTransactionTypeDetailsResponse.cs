namespace Application.CQRS.InventoryItemTransactionType;

public record InventoryItemTransactionTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);