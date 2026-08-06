namespace Application.CQRS.InventoryItemCost;

public record InventoryItemCostDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    long? InventoryItemFk,
    int? CompanyFk,
    decimal? AvgCost,
    decimal? TotalQuantity
);