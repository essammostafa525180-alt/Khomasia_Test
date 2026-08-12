namespace Application.CQRS.InventoryItemReturnBatch;

public record InventoryItemReturnBatchDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? ItemReturnDetailFk,
    decimal? ReturnedQuantity,
    int? ReturnReasonFk,
    int? RwDeliveredBatchFk,
    string? Notes,
    int? BatchFk
);