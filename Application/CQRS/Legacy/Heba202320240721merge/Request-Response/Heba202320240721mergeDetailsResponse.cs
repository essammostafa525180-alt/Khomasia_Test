namespace Application.CQRS.Legacy.Heba202320240721merge;

public record Heba202320240721mergeDetailsResponse
(
         long Id,
         string? DeletedItemNumber,
         string? ItemNumber,
         long? InventoryItemFk,
         double? NewAverageCost,
         double? DeletedAverageCost
);
