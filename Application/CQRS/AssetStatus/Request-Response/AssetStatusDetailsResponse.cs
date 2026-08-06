namespace Application.CQRS.AssetStatus;

public record AssetStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);