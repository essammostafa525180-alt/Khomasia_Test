namespace Application.CQRS.AssetScrapStatus;

public record AssetScrapStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);