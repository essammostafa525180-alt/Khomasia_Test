namespace Application.CQRS.Legacy.Cairo202320240721;

public record Cairo202320240721DetailsResponse
(
         string? ItemNumber,
         string? ItemName,
         double? Store2,
         double? Store3,
         double? Store9,
         double? AverageCost,
         double? Quantity,
         double? TotalCost,
         long? InventoryItemFk
);
