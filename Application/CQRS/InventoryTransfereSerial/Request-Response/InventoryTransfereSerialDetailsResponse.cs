namespace Application.CQRS.InventoryTransfereSerial;

public record InventoryTransfereSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryTransfereFk,
    int? InventoryTransfereDetailFk,
    int? InventoryItemSerialFk
);