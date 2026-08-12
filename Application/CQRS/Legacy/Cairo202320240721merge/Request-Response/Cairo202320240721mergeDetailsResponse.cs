namespace Application.CQRS.Legacy.Cairo202320240721merge;

public record Cairo202320240721mergeDetailsResponse
(
         long Id,
         string? DeletedItemNumber,
         string? ItemNumber,
         long? InventoryItemFk,
         double? DeletedAverageCost,
         double? NewAverageCost
);
