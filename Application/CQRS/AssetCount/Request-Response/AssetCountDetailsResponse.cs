namespace Application.CQRS.AssetCount;

public record AssetCountDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? AssetCountNumber,
    int? AssetTakerUserFk,
    DateTime? CountDate,
    int? ZoneFk,
    int? AssetCountPlanFk
);