namespace Application.CQRS.Legacy.Heba202320240721;

public record Heba202320240721DetailsResponse
(
         string? ItemNumber,
         string? ItemName,
         double? Store1,
         double? Store4,
         double? Store5,
         double? Store6,
         double? Store7,
         double? Store8,
         double? AverageCost,
         double? Quantity,
         double? TotalCost,
         long? InventoryItemFk
);
