namespace Application.CQRS.AssetItemMove;

public record AssetItemMoveDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    int? AssetItemFk,
    int? AssetMoveTypeFk,
    int? FromProjectFk,
    int? FromAssetLocationFk,
    int? ToProjectFk,
    int? ToAssetLocationFk,
    int? EmployeeFk,
    DateOnly? MoveDate,
    int? OwnerApprovedFk,
    int? IsOwnerApprovedFk,
    DateTime? OwnerApprovedDate,
    int? ManagerApprovedFk,
    int? IsManagerApprovedFk,
    DateTime? ManagerApprovedDate
);