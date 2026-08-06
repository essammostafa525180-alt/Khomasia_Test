namespace Application.CQRS.InventoryItemReturnSerial;

public record InventoryItemReturnSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryItemReturnFk,
    int? InventoryItemReturnDetailFk,
    int? InventoryItemSerialFk
);