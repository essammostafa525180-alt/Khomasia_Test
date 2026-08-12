namespace Application.CQRS.AssetItemScrap;

public record AssetItemScrapDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AssetItemFk,
    string? Code,
    int? AssetItemMoveFk,
    int? AssetItemMaintenanceFk,
    int? AssetScrapStatusFk,
    int? ApprovalStatusFk,
    decimal? SoldAmount,
    DateTime? ActionDate
);