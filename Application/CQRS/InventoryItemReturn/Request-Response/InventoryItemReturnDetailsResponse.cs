namespace Application.CQRS.InventoryItemReturn;

public record InventoryItemReturnDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RequestWithdrawFk,
    string? ReturnNo,
    DateTime? ReturnDate,
    int? ReturnedByFk,
    string? ReturnedBy,
    string? DescriptionEn,
    string? DescriptionAr,
    int? ItemReturnStatusFk,
    bool? IsAprove,
    bool? Axsynced,
    int? SourceId
);