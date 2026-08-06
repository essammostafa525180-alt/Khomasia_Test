namespace Application.CQRS.VendorReturnDetailBatchSerial;

public record VendorReturnDetailBatchSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorReturnDetailBatchFk,
    int? SerialFk,
    int? ReturnReasonFk,
    string? Notes
);