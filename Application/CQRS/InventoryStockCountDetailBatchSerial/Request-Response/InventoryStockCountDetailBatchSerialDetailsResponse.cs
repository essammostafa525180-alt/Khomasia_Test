namespace Application.CQRS.InventoryStockCountDetailBatchSerial;

public record InventoryStockCountDetailBatchSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryStockCountDetailBatchFk,
    int? InventoryItemLocationBatchSerialFk,
    bool IsNew,
    bool IsSerialExist
);