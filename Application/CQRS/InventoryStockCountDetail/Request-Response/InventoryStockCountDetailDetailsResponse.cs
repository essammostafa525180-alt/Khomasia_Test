namespace Application.CQRS.InventoryStockCountDetail;

public record InventoryStockCountDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryStockCountFk,
    long? InventoryItemFk,
    decimal? Quantity,
    decimal? CountQuantity,
    string? IncDecReason
);