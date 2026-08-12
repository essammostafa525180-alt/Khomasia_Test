namespace Application.CQRS.VendorOrderReceiveDetailBatchSerial;

public record VendorOrderReceiveDetailBatchSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderReceiveDetailBatchFk,
    string? SerialNumber
);