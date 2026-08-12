namespace Application.CQRS.RwDeliveredBatch;

public record RwDeliveredBatchDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RequestWdfk,
    decimal? ReturnedQuantity,
    decimal? DeliveredQuantity,
    DateTime? DeliveredDate,
    int? BatchFk,
    bool? Axsynced
);