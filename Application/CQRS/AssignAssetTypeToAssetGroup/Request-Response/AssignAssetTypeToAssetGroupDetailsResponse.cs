namespace Application.CQRS.AssignAssetTypeToAssetGroup;

public record AssignAssetTypeToAssetGroupDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AssetTypeFk,
    int? AssetGroupFk
);