namespace Application.CQRS.PoserviceAsset;

public record PoserviceAssetDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int PoserviceFk,
    int ContractServiceId,
    int ContractAssetId,
    int AssetId,
    string? AssetCode,
    string? AssetDescription,
    string? AssetDescriptionAr
);