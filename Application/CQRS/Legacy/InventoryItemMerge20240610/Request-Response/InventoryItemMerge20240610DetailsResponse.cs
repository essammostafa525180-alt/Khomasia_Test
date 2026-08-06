namespace Application.CQRS.Legacy.InventoryItemMerge20240610;

public record InventoryItemMerge20240610DetailsResponse
(
         string? ItemNumber2024,
         string? ItemNumber2023,
         long? ItemNumber2024Id,
         long? ItemNumber2023Id,
         decimal? TotalQuantity2023,
         decimal? OpeningQuantity2024,
         decimal? TotalQuantity2024
);
