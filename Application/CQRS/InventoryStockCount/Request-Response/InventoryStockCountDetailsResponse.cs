namespace Application.CQRS.InventoryStockCount;

public record InventoryStockCountDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);