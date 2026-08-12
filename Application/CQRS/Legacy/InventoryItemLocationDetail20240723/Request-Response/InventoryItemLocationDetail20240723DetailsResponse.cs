namespace Application.CQRS.Legacy.InventoryItemLocationDetail20240723;

public record InventoryItemLocationDetail20240723DetailsResponse
(
         long Id,
         DateTime? CreatedOn,
         DateTime? LastUpdatedOn,
         long? CreatedBy,
         long? LastUpdatedBy,
         bool IsActive,
         byte[] RowVersion,
         long? StoreFk,
         long? InventoryItemFk,
         long? ItemQuantityTypeFk,
         long? TransactionTypeFk,
         string? Screen,
         long? EntityId,
         string? EntityCode,
         DateTime? EntityDate,
         long? EntityDetailId,
         long? InventoryItemLocationFk,
         decimal? QuantityBefore,
         decimal Quantity,
         decimal? QuantityAfter,
         decimal? EntityDetailCost,
         double? Avgcost
);
