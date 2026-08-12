namespace Application.CQRS.AssetCountPlanStatus;

public record AssetCountPlanStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);