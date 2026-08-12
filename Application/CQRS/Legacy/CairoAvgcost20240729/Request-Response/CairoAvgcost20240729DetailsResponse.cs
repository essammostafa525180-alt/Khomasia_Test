namespace Application.CQRS.Legacy.CairoAvgcost20240729;

public record CairoAvgcost20240729DetailsResponse
(
         double? Id,
         string? ItemNumber,
         string? ItemName,
         string? Store,
         double? OpeningBalance,
         double? Avgcost,
         double? TotalCost
);
