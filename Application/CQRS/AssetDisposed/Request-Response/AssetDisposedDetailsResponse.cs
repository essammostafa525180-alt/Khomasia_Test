namespace Application.CQRS.AssetDisposed;

public record AssetDisposedDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? OrganizationName,
    decimal? Cost,
    string? Notes
);