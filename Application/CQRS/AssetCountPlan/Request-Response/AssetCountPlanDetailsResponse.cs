namespace Application.CQRS.AssetCountPlan;

public record AssetCountPlanDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? PlanNumber,
    string? Name,
    string? NameAr,
    int? AssetCountPlanTypeFk,
    int? AssetCountPlanStatusFk,
    DateTime? PlaneDate,
    DateTime? ExecutionDate,
    int? AssignedToUserFk
);