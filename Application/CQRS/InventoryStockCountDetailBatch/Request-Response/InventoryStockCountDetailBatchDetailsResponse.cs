namespace Application.CQRS.InventoryStockCountDetailBatch;

public record InventoryStockCountDetailBatchDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryStockCountDetailFk,
    int? BatchFk,
    decimal? Quantity,
    decimal? CountQuantity
);