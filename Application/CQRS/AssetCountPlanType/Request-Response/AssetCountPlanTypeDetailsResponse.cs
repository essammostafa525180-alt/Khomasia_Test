namespace Application.CQRS.AssetCountPlanType;

public record AssetCountPlanTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);