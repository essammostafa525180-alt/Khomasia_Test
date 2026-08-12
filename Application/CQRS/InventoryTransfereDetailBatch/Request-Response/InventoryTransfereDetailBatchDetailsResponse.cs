namespace Application.CQRS.InventoryTransfereDetailBatch;

public record InventoryTransfereDetailBatchDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryTransfereDetailFk,
    int? BatchFk,
    string? NewBatchNumber,
    decimal? Qunatity,
    DateTime? ExpiryDate,
    int? ShelfFk
);