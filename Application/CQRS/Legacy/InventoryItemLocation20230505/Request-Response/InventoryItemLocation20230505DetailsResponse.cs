namespace Application.CQRS.Legacy.InventoryItemLocation20230505;

public record InventoryItemLocation20230505DetailsResponse
(
         long Id,
         long? InventoryItemFk,
         long? StoreFk,
         decimal? Quantity,
         long? ItemQuantityTypeFk,
         DateTime? CreatedOn,
         DateTime? LastUpdatedOn,
         long? CreatedBy,
         long? LastUpdatedBy,
         bool IsActive,
         byte[] RowVersion
);
