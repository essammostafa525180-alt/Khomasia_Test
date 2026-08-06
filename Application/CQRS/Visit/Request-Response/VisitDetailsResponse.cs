namespace Application.CQRS.Visit;

public record VisitDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? CustomerId,
    int? UserId,
    decimal? Latitude,
    decimal? Longitude,
    string? Image,
    string? OtherSupplier,
    DateTime? UpdatedOn,
    int? UpdatedBy
);