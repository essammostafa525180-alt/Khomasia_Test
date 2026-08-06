namespace Application.CQRS.VendorOrderReceiveDetailBatch;

public record VendorOrderReceiveDetailBatchDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderReceiveDetailFk,
    int? ShelfFk,
    string? BatchNumber,
    decimal? Quantity,
    decimal? ReturnedQuantity,
    DateTime? ExpiryDate,
    DateTime? ProductionDate
);