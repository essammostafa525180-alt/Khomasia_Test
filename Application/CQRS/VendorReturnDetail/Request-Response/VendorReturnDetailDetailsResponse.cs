namespace Application.CQRS.VendorReturnDetail;

public record VendorReturnDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorReturnFk,
    long? InventoryItemFk,
    decimal? Quantity,
    int? ReturnReasonFk
);