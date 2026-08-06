namespace Application.CQRS.AssetCompline;

public record AssetComplineDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);