namespace Application.CQRS.AssetCountStatus;

public record AssetCountStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);