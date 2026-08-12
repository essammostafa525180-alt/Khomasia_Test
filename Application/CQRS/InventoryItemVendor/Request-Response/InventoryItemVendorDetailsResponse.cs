namespace Application.CQRS.InventoryItemVendor;

public record InventoryItemVendorDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    long? InventoryItemFk,
    int? VendorFk,
    int? VendorOrder
);