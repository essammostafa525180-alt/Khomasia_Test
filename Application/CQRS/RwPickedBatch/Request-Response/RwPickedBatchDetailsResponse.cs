namespace Application.CQRS.RwPickedBatch;

public record RwPickedBatchDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RequestWdfk,
    decimal? ReturnedQuantity,
    decimal? PickedQuantity,
    DateTime? PickedDate,
    int? BatchFk,
    bool? Axsynced
);