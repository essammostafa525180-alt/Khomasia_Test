namespace Application.CQRS.Legacy.InventoryItemMerge20240522;

public record InventoryItemMerge20240522DetailsResponse
(
         string? ItemNumber2024,
         string? ItemNumber2023,
         long? ItemNumber2024Id,
         long? ItemNumber2023Id,
         decimal? TotalQuantity2023,
         decimal? OpeningQuantity2024,
         decimal? TotalQuantity2024
);
