namespace Application.CQRS.InventoryItemLocationBatch;

public record InventoryItemLocationBatchDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryItemLocationFk,
    string? BatchNumber,
    int? ShelfFk,
    decimal? TotalQuantity,
    DateTime? ExpiryDate,
    long? InventoryItemFk,
    DateTime? ProductionDate
);