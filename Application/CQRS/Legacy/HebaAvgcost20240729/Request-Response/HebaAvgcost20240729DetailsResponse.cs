namespace Application.CQRS.Legacy.HebaAvgcost20240729;

public record HebaAvgcost20240729DetailsResponse
(
         double? Id,
         string? ItemNumber,
         string? ItemName,
         string? Store,
         double? OpeningBalance,
         double? Avgcost,
         double? TotalCost
);
