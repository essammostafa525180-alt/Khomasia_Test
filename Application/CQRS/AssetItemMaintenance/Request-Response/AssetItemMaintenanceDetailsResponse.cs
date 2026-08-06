namespace Application.CQRS.AssetItemMaintenance;

public record AssetItemMaintenanceDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AssetItemFk,
    string? Code,
    int? AssetItemMoveFk,
    int? AssetMaintenanceStatusFk
);