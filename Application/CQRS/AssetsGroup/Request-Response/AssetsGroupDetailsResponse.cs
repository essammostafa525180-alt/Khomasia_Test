namespace Application.CQRS.AssetsGroup;

public record AssetsGroupDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr,
    decimal? DepreciationDuration,
    decimal? DepreciationRate
);