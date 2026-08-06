namespace Application.CQRS.InventoryItemReturnBatchSerial;

public record InventoryItemReturnBatchSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryItemReturnBatchFk,
    int? ReturnReasonFk,
    int? RwDelivedSerialFk,
    string? Notes
);