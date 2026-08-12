namespace Application.CQRS.Legacy.Heba2024;

public record Heba2024DetailsResponse
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
