namespace Application.CQRS.AssetFunctionality;

public record AssetFunctionalityDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);