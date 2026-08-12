namespace Application.CQRS.VendorReturnSerial;

public record VendorReturnSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorReturnFk,
    int? VendorReturnDetailFk,
    int? InventoryItemSerialFk
);