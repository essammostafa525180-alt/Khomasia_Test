namespace Application.CQRS.InventoryItemSerial;

public record InventoryItemSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);