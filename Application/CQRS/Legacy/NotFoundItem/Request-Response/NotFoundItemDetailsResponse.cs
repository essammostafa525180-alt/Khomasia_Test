namespace Application.CQRS.Legacy.NotFoundItem;

public record NotFoundItemDetailsResponse
(
         string? ItemCode,
         string? Store,
         double? Balance,
         DateTime? Date,
         string? Id,
         string? Code,
         string? Duplicated
);
