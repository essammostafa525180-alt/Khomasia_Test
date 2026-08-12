namespace Application.CQRS.Oil;

public record OilDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    double? StoreId,
    string? StoreName,
    DateTime? StockCountDate,
    double? InventoryItemId,
    string? InventoryItemCode,
    string? InventoryItemName,
    double? AvgCost,
    double? TotalQuantity,
    double? StockCountQuantity,
    double? Mmbalance,
    string? IsMatch,
    double? IsUpdated
);