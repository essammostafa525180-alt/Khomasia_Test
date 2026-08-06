namespace Application.CQRS.VendorReturnDetailBatch;

public record VendorReturnDetailBatchDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorReturnDetailFk,
    decimal? Quantity,
    int? ReturnReasonFk,
    string? Notes,
    int? BatchFk,
    int? VendorOrderReceiveDetailBatchFk
);