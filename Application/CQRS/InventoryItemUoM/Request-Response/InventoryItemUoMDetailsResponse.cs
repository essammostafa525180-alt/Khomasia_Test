namespace Application.CQRS.InventoryItemUoM;

public record InventoryItemUoMDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    long? InventoryItemFk,
    int? UnitOfMeasureFk,
    decimal? ConvertRate
);