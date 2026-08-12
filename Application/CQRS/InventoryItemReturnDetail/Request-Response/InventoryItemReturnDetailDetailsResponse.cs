namespace Application.CQRS.InventoryItemReturnDetail;

public record InventoryItemReturnDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryItemReturnFk,
    long? InventoryItemFk,
    decimal? ReturnedQuantity,
    int? ReturnReasonFk,
    string? Notes,
    decimal? ExternalReturnedQuantity,
    int? RequestWdfk
);