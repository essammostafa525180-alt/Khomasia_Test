namespace Application.CQRS.InventoryItemLocationBatchSerial;

public record InventoryItemLocationBatchSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryItemLocationBatchFk,
    string? SerialNumber,
    bool? IsAvailable
);