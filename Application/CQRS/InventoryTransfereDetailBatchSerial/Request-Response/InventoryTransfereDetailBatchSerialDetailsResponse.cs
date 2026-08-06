namespace Application.CQRS.InventoryTransfereDetailBatchSerial;

public record InventoryTransfereDetailBatchSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryTransfereDetailBatchFk,
    int? SerialFk
);