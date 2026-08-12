namespace Application.CQRS.Legacy.InventoryItemLocation20240723;

public record InventoryItemLocation20240723DetailsResponse
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
