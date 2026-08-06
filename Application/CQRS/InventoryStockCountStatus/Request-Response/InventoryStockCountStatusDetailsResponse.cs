namespace Application.CQRS.InventoryStockCountStatus;

public record InventoryStockCountStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);