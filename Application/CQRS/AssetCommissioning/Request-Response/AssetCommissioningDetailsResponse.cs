namespace Application.CQRS.AssetCommissioning;

public record AssetCommissioningDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AssetFk,
    int? CommissionConditionFk,
    int? AssetFunctionalityFk,
    int? AssetComplineFk,
    int? SubSectionFk
);