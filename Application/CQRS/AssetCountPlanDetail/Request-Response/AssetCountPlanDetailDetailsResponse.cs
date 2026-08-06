namespace Application.CQRS.AssetCountPlanDetail;

public record AssetCountPlanDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AssetCountPlanFk,
    int? ZoneFk,
    int? AssignedToUserFk
);