namespace Application.CQRS.Legacy.Cairo2024;

public record Cairo2024DetailsResponse
(
         string? Store,
         string? ItemName,
         double? Quantity,
         string? MaterialGroup,
         string? MaterialCategory,
         string? MaterialSubCategory,
         string? UnitOfMeasure,
         long? InventoryItemFk,
         long? StoreFk
);
