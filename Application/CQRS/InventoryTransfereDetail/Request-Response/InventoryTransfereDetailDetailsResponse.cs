namespace Application.CQRS.InventoryTransfereDetail;

public record InventoryTransfereDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryTransfereFk,
    long? InventoryItemFk,
    decimal? Quantity
);