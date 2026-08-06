namespace Application.CQRS.Legacy.StockCount20230331;

public record StockCount20230331DetailsResponse
(
         string? ItemCode,
         string? Store,
         double? Balance,
         string? Date,
         int Id,
         string? ItemNumber
);
