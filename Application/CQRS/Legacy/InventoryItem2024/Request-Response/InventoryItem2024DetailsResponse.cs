namespace Application.CQRS.Legacy.InventoryItem2024;

public record InventoryItem2024DetailsResponse
(
         string? Store,
         string? ItemCardEn,
         string? ItemCardAr,
         string? MaterialGroup,
         string? MaterialCategory,
         string? MaterialSubCategory,
         double? TotalQuantity,
         string? UnitOfMeasure,
         string? MaterialGroup1,
         long? MaterialGroupFk,
         long? MaterialCategoryFk,
         long? MaterialSubCategoryFk,
         long? UnitOfMeasureFk
);
