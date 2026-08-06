namespace Application.CQRS.Legacy.MotorodItem;

public record MotorodItemDetailsResponse
(
         string? MaterialGroup,
         string? ItemCategory,
         string? ItemName,
         string? Unit,
         double? Price
);
