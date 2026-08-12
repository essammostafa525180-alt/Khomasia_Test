namespace Application.CQRS.VendorOrderReceiveSerial;

public record VendorOrderReceiveSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderReceiveFk,
    int? VendorOrderReceiveDetailFk,
    int? InventoryItemSerialFk
);