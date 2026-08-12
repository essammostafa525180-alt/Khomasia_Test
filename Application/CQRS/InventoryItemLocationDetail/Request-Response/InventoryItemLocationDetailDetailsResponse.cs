namespace Application.CQRS.InventoryItemLocationDetail;

public record InventoryItemLocationDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? StoreFk,
    long? InventoryItemFk,
    int? ItemQuantityTypeFk,
    int? TransactionTypeFk,
    string? Screen,
    int? EntityId,
    string? EntityCode,
    DateTime? EntityDate,
    int? EntityDetailId,
    int? InventoryItemLocationFk,
    decimal? QuantityBefore,
    decimal Quantity,
    decimal? QuantityAfter,
    decimal? EntityDetailCost,
    decimal? Avgcost,
    int? InventoryItemLocationBatchFk
);