namespace Application.CQRS.AnnualStockCountItemQuantity;

public record AnnualStockCountItemQuantityDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AnnualStockCountFk,
    long? InventoryItemFk,
    string? NewName,
    decimal? CurrentQuantity,
    decimal? StockQuantity,
    Guid? RefId
);