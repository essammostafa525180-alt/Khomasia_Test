namespace Application.CQRS.InventoryItemAsset;

public record InventoryItemAssetDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    long? InventoryItemFk,
    int? AssetFk
);