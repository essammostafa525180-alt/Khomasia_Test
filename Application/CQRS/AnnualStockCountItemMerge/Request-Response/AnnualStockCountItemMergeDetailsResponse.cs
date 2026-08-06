namespace Application.CQRS.AnnualStockCountItemMerge;

public record AnnualStockCountItemMergeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AnnualStockCountFk,
    long? InventoryItemFk,
    decimal? CurrentQuantity,
    long? ActiveInventoryItemFk
);