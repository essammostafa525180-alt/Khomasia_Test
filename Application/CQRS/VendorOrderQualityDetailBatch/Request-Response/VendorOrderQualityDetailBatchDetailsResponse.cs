namespace Application.CQRS.VendorOrderQualityDetailBatch;

public record VendorOrderQualityDetailBatchDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderQualityDetailFk,
    int? ShelfFk,
    string? BatchNumber,
    decimal? Quantity,
    DateTime? ExpiryDate,
    DateTime? ProductionDate
);