namespace Application.CQRS.RwPickedQuantity;

public record RwPickedQuantityDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RequestWdfk,
    decimal? PickedQuantity,
    DateTime? PickedDate,
    bool? Axsynced
);